using UnityEngine;
using System.Collections;

public class SDoor: MonoBehaviour {

	public Player player;
	public GameObject sk;
	public Password password;
	public bool close;

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
			if (player.hasItem == 3) {
				sk = GameObject.Find ("key_silver");
				sk.transform.position = transform.position;
				sk.transform.parent = transform.parent;
				sk.GetComponent<Collider> ().enabled = false;
				password.Skey = true;
			}
		}
	}
}