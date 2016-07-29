using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BotDam : MonoBehaviour {

	public BotMove enemyAgent;
	public EnemyBullet enemyBullet;
	public int health;
	public GameObject boom;

	public Slider npchealthSlider;

	void Start () {
//		health = 5;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet"){
			health -= 1;
			npchealthSlider.value = health;
			if (health < 1){
				GameObject bom = (GameObject)Instantiate(boom);
				bom.transform.position = transform.position;
				enemyAgent.gameObject.SetActive (false);
			}
		}
	}
}