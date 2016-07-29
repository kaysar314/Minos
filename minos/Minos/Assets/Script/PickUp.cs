using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PickUp : MonoBehaviour {

	public Bag backPack;
	public GameObject canvas;
	public GameObject swo;
	public GameObject caesar;

	public float pickTime;
	public float pickRate;

	Dictionary<string, int> subjects = new Dictionary<string, int>();

	public bool close2sword;

	void OnTriggerStay(Collider other){
		foreach (KeyValuePair<string, int> kvp in subjects)
		{
			if (other.gameObject.tag == kvp.Key && (Time.time > pickTime)){
				Debug.Log(kvp.Key);
				int count = backPack.subjects.Count;

				if(count < 5 && Input.GetKeyUp(KeyCode.E)){
					
					backPack.subjects.Add (kvp.Value);
					backPack.pick = true;
					pickTime = Time.time + pickRate;
				}
			}
		}
	}

	void Start () {
		subjects.Add("Torch", 0);
		subjects.Add("Gun", 1);

		pickRate = 0.2f;
		pickTime = -1f;

		close2sword = false;
		backPack = canvas.GetComponent<Bag> ();
	}

	void Update(){
		if (Input.GetKeyUp (KeyCode.G)) {
			int count = backPack.subjects.Count; 

			backPack.subjects.RemoveAt(count-1);
			backPack.pick = true;
			pickTime = Time.time + pickRate;
		} 
	}
}