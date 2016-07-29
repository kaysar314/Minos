using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public bool canPickUp = false;
	public bool hasTorch = false;

	public Player player;
	public Bag backPack;

	public GameObject rHandSocket;
	// Use this for initialization
	void Start () {
		rHandSocket = GameObject.Find ("TorchHolder");
		backPack =  GameObject.Find ("Bag").GetComponent<Bag> ();
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update () {
		if (!hasTorch) {
			if (canPickUp && Input.GetKeyUp (KeyCode.E)) {
				PickUp ();
			}
		} else {
			if (Input.GetKeyUp (KeyCode.G)) {
			}
//				Drop ();
		}
	}

	public void init(){
		canPickUp = false;
		hasTorch = false;
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
		backPack.subjects.Add (0);
		backPack.pick = true;
		if (backPack.subjects.Count > 1) {
			player.Switch (backPack.subjects.Count-1);
		}
		player.hasItem = 0;
		// change position of torch to rHandSocket
		gameObject.transform.position = rHandSocket.transform.position;
		gameObject.transform.rotation = rHandSocket.transform.rotation;
		gameObject.transform.parent = rHandSocket.transform;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = true;
		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = false;
		//gameObject.collider.enabled = false; //this doesn't work.
		hasTorch = true;

		GameObject.Find ("Stories").GetComponent<StoriesControl> ().storyNum = 2;
		GameObject.Find ("Stories").GetComponent<StoriesControl> ().show = true;
	}

	void Drop(){
		backPack.subjects.Remove (0);
		// change position of torch to ground
		gameObject.transform.parent = null;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = true;
		hasTorch = false;
	}
}