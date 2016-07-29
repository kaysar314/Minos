using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Password : MonoBehaviour {

	public bool Skey;
	public bool Gkey;
	public bool close;
	public GameObject pass;
	public GameObject player;
	public FirstPersonController fpc;
	public bool stoShow;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player"){
			close = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			close = false;
			pass.SetActive (false);
			fpc.LockM ();
		}
	}

	// Use this for initialization
	void Start () {
		fpc = player.GetComponent<FirstPersonController> ();
		Skey = false;
		Gkey = false;
		stoShow = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Skey && Gkey && close && Input.GetKeyUp(KeyCode.E)){
			pass.SetActive (true);
			if (stoShow) {
				stoShow = false;
				GameObject.Find ("Stories").GetComponent<StoriesControl> ().storyNum = 5;
				GameObject.Find ("Stories").GetComponent<StoriesControl> ().show = true;
			}
			fpc.unLockM ();
		}
	}
}