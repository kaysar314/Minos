using UnityEngine;
using System.Collections;

public class TreasureBox : MonoBehaviour {

	public Player player;
	public bool close;

	public int type;

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
		if (close && Input.GetKeyUp(KeyCode.E)) {
			if (type == 1) {
				player.health += 15;
			}
			if (type == 2) {
				player.blurOn = true;
			}
			Destroy (gameObject, 0f);
		}
	}
}



