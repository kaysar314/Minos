using UnityEngine;
using System.Collections;

public class Map: MonoBehaviour {

	public bool canPickUp = false;
	public bool hasMap = false;
	public GameObject map;
	public Player player;
	public Bag backPack;

	void Start () {		
		
		backPack =  GameObject.Find ("Bag").GetComponent<Bag> ();
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		if (!hasMap) {
			if (canPickUp && Input.GetKeyUp (KeyCode.E)) {
				PickUp ();
			}
		} else {
			if (Input.GetKeyUp (KeyCode.G)) {
			}
			//				Drop ();
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			canPickUp = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			canPickUp = false;
		}
	}

	void PickUp(){
		hasMap = true;
//		backPack.subjects.Add (5);
		player.hasMap = true;
//		backPack.pick = true;
		map.SetActive (true);
		gameObject.SetActive (false);
		GameObject.Find ("Stories").GetComponent<StoriesControl> ().storyNum = 3;
		GameObject.Find ("Stories").GetComponent<StoriesControl> ().show = true;
	}
}