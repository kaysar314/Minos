using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour {

	public Player player;
	public Bullet bullet;
	public bool close;
	// Use this for initialization
	void Start () {
		close = false;
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
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

	// Update is called once per frame
	void Update () {
		if (close && Input.GetKey(KeyCode.E)) {
			if (player.hasItem == 1) {
				GameObject.Find ("FPSController").GetComponentInChildren<Bullet> ().bullSum += 14;
				Destroy (gameObject, 0f);
			}
		}
	}
}
