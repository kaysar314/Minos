using UnityEngine;
using System.Collections;

public class BotDamkey : MonoBehaviour {

	public BotMove enemyAgent;
	public EnemyBullet enemyBullet;

	public int health;
	public GameObject boom;

	public bool hasKey;
	public GameObject key;
	public GameObject ground;

	void Start () {
		health = 5;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet"){
			health -= 1;
			if (health < 1){
				GameObject bom = (GameObject)Instantiate(boom);
				bom.transform.position = transform.position;
				key.transform.parent = null;

				(key.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
				(key.GetComponent (typeof(BoxCollider)) as Collider).enabled = true;
				enemyAgent.gameObject.SetActive (false);
			}
		}
	}
}