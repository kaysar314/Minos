using UnityEngine;
using System.Collections;

public class EnemyDam : MonoBehaviour {

	public EnemyMove enemyAgent;
	public EnemyBullet enemyBullet;
	public Player player;
	public GameObject obj;
	public int health;

	public bool death;

	public float frozenTime;
	public float nextFrozen;
	// Use this for initialization
	void Start () {
		death = false;
		frozenTime = 5f;
		nextFrozen = 0f;
		enemyAgent = gameObject.GetComponentInParent<EnemyMove> ();
		obj = GameObject.Find ("FPSController");
		player = obj.GetComponent<Player> ();
		health = 5;
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet"){
			enemyAgent.agent.SetDestination(new Vector3(obj.transform.position.x, enemyAgent.transform.position.y, obj.transform.position.z));
			health -= 1;

			if (other.gameObject.transform.localScale.x == 1.4f) {
				health -= 4;
			}
			if (other.gameObject.transform.localScale.x == 4f) {
				health += 1;
				enemyAgent.canMove = false;
				enemyBullet.canShoot = false;
				nextFrozen = Time.time + frozenTime;
			}
			if (health < 1){
//				player.killEnemy += 1;
				GameObject bom = (GameObject)Instantiate(enemyAgent.boom);
				bom.transform.position = transform.position;
				enemyAgent.agent = null;
				Destroy (enemyAgent.gameObject, 0f);
			}
		}
	}

	void Update () {
		if (Time.time > nextFrozen && !enemyBullet.canShoot){
			enemyAgent.canMove = true;
			enemyBullet.canShoot = true;
		}
	}
}