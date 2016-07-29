using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public Player player;
	public GameObject obj;
	public GameObject boom;
	public NavMeshAgent agent; 

	public bool attack;

	public bool canMove;

	// Use this for initialization
	void Start () {
		canMove = true;
		attack = false;
		obj = GameObject.Find ("FPSController");
		player = obj.GetComponent<Player> ();
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updatePosition = true;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player" ){
			if (!attack) {
				attack = true;
				agent.SetDestination (transform.position);
			}
			Vector3 pos = other.gameObject.transform.position;
			RaycastHit hit;
			Physics.Raycast (this.transform.position, (pos - this.transform.position).normalized,out hit);

			if (agent && attack) {
				if (agent.remainingDistance < 2f) {
					agent.SetDestination (new Vector3(rand(transform.position.x,10f),transform.position.y,rand(transform.position.z,10f)));
				}
			}
		}
	}

//	void OnTriggerEnter(Collider other){
//		if (other.gameObject.tag == "Bullet"){
//			health -= 1;
//
//			if (other.gameObject.transform.localScale.x > 1.5f) {
//				health -= 4;
//			}
//			if (health < 1){
//				player.killEnemy += 1;
//				GameObject bom = (GameObject)Instantiate(boom);
//				bom.transform.position = transform.position;
//				agent = null;
//				Destroy (gameObject, 0f);
//			}
//		}
//	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player" && canMove){
			attack = false;
			if (agent){
				agent.SetDestination (new Vector3(rand(transform.position.x,30f),transform.position.y,rand(transform.position.z,30f)));
			}
		}
		if (!canMove) {
			agent.SetDestination (transform.position);
		}
	}

	// Update is called once per frame
	void Update () {
		if (agent  && canMove){
			if (agent.remainingDistance < 10f && !attack) {
				agent.SetDestination (new Vector3(rand(transform.position.x,30f),transform.position.y,rand(transform.position.z,30f)));
			}
		}
		if (!canMove) {
			agent.SetDestination (transform.position);
		}

	}

	public float rand(float num,float range){
		return (num + (range * Random.Range(-1f, 1f)));
	}
}
