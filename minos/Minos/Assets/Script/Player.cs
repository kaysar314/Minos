using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int amount = 2;
	public int health;
	public Slider healthSlider;
	public Image damageImage;
	public Image screenImage;
	public Text healthText;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.5f);

	public List<GameObject> items = new List<GameObject>();
	public Bag backPack;
	public GameObject canvas;
	public GameObject map;
	public GameObject myp;
	public GameObject blur;
	public bool blurOn;

	public int killEnemy;

	public bool hasMap;
	public int hasItem;

	private GameObject SG;
	void Start () {
		blurOn = false;
		backPack = canvas.GetComponent<Bag> ();
		hasMap = false;
		hasItem = -1;
		health = 100;
		killEnemy = 0;
		SG = GameObject.Find ("StartGame");
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "EnemyBullet"){
			health -= (int)Random.Range(0f, 4f);
			ScreenRed ();
		}
		if (other.gameObject.tag == "EnemyBossBullet"){
			health -= (int)Random.Range(2f, 6f);
			ScreenRed ();
		}
	}

	public void ScreenRed(){
		screenImage.color = flashColour;
	}

	void OnGUI(){
		if (SG.activeInHierarchy == false) {
			if (health < 1) {
				Time.timeScale = 0;
				GUI.backgroundColor = Color.black;
				GUI.color = Color.red;
				if (GUI.Button (new Rect (0, 0, Screen.width, Screen.height), "YOU HAVE LOST !!\n Try AGAIN ?")) {
					Time.timeScale = 1;
					GameObject.Find ("Ground").GetComponent<Ready> ().init();
				}
			}
		}
	}

	void Update () {
		
		screenImage.color = Color.Lerp(screenImage.color, Color.clear, flashSpeed * Time.deltaTime);
		healthText.text = health + "/100";
		if(health < 60)
		{
			damageImage.color = new Color(255, 0, 0);
		} else
		{
			damageImage.color = new Color(0, 255, 0);
		}
		healthSlider.value = health;

		if (blurOn){
			blurOn = false;
			blur.SetActive (true);
			Invoke ("blurOff", 8.0f);
		}

//		myp.transform.position = new Vector3 (((transform.localPosition.x + 43) * (8.63f)), ((transform.localPosition.z - 43.3f) * (-8.63f)),-0.1f);
		if(Input.GetKeyUp (KeyCode.M) && hasMap){
			map.SetActive (!map.activeInHierarchy);
		}
		if(Input.GetKeyUp (KeyCode.Alpha1)){
			Switch (0);
		}
		if(Input.GetKeyUp (KeyCode.Alpha2)){
			Switch (1);
		}
		if(Input.GetKeyUp (KeyCode.Alpha3)){
			Switch (2);

		}
		if(Input.GetKeyUp (KeyCode.Alpha4)){
			Switch (3);
		}
		if(Input.GetKeyUp (KeyCode.Alpha5)){
			Switch (4);
		}
		if(Input.GetKeyUp (KeyCode.I)){
			GameObject.Find ("Ground").GetComponent<Ready> ().init();
		}
	}

	public void Switch(int num){
		int count = backPack.subjects.Count; 
		if (count > num) {
			hasItem = backPack.subjects [num];
			for (int i = 0; i < count; i++){
				if (i == num) {
					items [backPack.subjects [i]].SetActive(true);
				} else {
					items [backPack.subjects [i]].SetActive (false);
				}
			}

		}
	}

	public void init(){
		backPack = canvas.GetComponent<Bag> ();
		hasMap = false;
		hasItem = -1;
		health = 20;
		killEnemy = 0;
		backPack.init ();
	}

	void blurOff(){
		blur.SetActive (false);
	}
}