using UnityEngine;
using System.Collections;

public class FInish : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			Debug.Log("R2");
			Application.LoadLevel("R2");

		}
	}
}
