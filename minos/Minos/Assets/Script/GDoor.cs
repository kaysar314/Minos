using UnityEngine;
using System.Collections;

public class GDoor: MonoBehaviour {

	public Player player;
	public GameObject gk;
	public Password password;
	public bool close;
	// Use this for initialization
	void Start () {
		close = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			close = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			close = false;
		}
	}

	void Update () {
		if (close && Input.GetKey(KeyCode.E)) {
			if (player.hasItem == 2) {
				gk = GameObject.Find ("Goldkey(Clone)");
				gk.transform.position = transform.position;
				gk.transform.parent = transform.parent;
				gk.GetComponent<Collider> ().enabled = false;
				password.Gkey = true;
			}
		}
	}
}
