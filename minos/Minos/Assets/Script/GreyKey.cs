using UnityEngine;
using System.Collections;

public class GreyKey : MonoBehaviour {

	public bool canPickUp = false;
	public bool hasGkey = false;

	public Player player;
	public Bag backPack;
	public GameObject rHandSocket;

	void Start () {
		rHandSocket = GameObject.Find ("GreyKeyHolder");
		backPack =  GameObject.Find ("Bag").GetComponent<Bag> ();
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
	}

	void Update () {
		if (!hasGkey) {
			if (canPickUp && Input.GetKeyUp (KeyCode.E)) {
				PickUp ();
			}
		}
	}

	public void init(){
		canPickUp = false;
		hasGkey = false;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = true;
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
		backPack.subjects.Add (4);
		backPack.pick = true;
		if (backPack.subjects.Count > 1) {
			player.Switch (backPack.subjects.Count-1);
		}
		player.hasItem = 4;
		// change position of torch to rHandSocket
		gameObject.transform.position = rHandSocket.transform.position;
		gameObject.transform.rotation = rHandSocket.transform.rotation;
		gameObject.transform.parent = rHandSocket.transform;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = true;
		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = false;
		//gameObject.collider.enabled = false; //this doesn't work.
		hasGkey = true;
	}

	void Drop(){
		backPack.subjects.Remove (0);
		// change position of torch to ground
		gameObject.transform.parent = null;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = true;
		hasGkey = false;
	}
}