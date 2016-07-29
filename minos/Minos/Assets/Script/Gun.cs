using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public bool canPickUp = false;
	public Player player;
	public bool hasGun = false;
	public Bag backPack;
	public GameObject gunHolder;
	// Use this for initialization
	void Start () {
		gunHolder = GameObject.Find ("GunHolder");
		backPack =  GameObject.Find ("Bag").GetComponent<Bag> ();
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasGun) {
			if (canPickUp && Input.GetKeyUp (KeyCode.E)) {
				PickUp ();
			}
		} else {
			if (Input.GetKeyUp (KeyCode.G)) {
				Drop ();
			}
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

	public void init(){
		canPickUp = false;
		hasGun = false;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
//		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = true;
	}

	void PickUp(){
		backPack.subjects.Add (1);
		backPack.pick = true;
		if (backPack.subjects.Count > 1) {
			player.Switch (backPack.subjects.Count-1);
		}
		player.hasItem = 1;
		// change position of gun to rHandSocket
		gameObject.transform.position = gunHolder.transform.position;
		gameObject.transform.rotation = gunHolder.transform.rotation;
		gameObject.transform.parent = gunHolder.transform;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = true;
//		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = false;
		//gameObject.collider.enabled = false; //this doesn't work.
		hasGun = true;
//		GameObject.Find ("Stories").GetComponent<StoriesControl> ().storyNum = 1;
//		GameObject.Find ("Stories").GetComponent<StoriesControl> ().show = true;
	}

	void Drop(){
		// change position of gun to ground
		gameObject.transform.parent = null;
		(gameObject.GetComponent (typeof(Rigidbody)) as Rigidbody).isKinematic = false;
//		(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = true;
		hasGun = false;
	}
}