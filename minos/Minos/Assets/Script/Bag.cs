using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Bag : MonoBehaviour {

	public int backPackSize;
	public List<GameObject> items = new List<GameObject>();
	public List<Sprite> sprites = new List<Sprite>();
	public Sprite emptySpr = new Sprite();
	public List<int> subjects = new List<int>();
	public GameObject empty;

	public GameObject grid;
	public GameObject sub;
	public GameObject pack;
	public GameObject player;

	public List<GameObject> playerItems = new List<GameObject>();
	public List<GameObject> packItems = new List<GameObject>();

	public bool pick;

	void Start () {
		pick = false;
		//		backPackSize = 5;
		for (int i = 0; i < backPackSize; i++) {
			GameObject emp = (GameObject)Instantiate (empty);
			emp.transform.SetParent(transform);
			Vector3 pos = emp.transform.localPosition;
			emp.transform.localPosition = new Vector3 (pos.x + 70*i, pos.y+539, 0);
			items.Add (emp);
		}
	}

	void Update () {
		if ( pick == true ) {
			pick = false;
			for (int i = 0; i < subjects.Count; i++) {
				Image img = items[i].GetComponent<Image> ();
				img.sprite = sprites [subjects [i]];
			}
			for (int i = subjects.Count; i < backPackSize; i++) {
				Image img = items[i].GetComponent<Image> ();
				img.sprite = emptySpr;
			}
		}
	}

	public void init(){
		if(subjects.Count > 0){
			subjects.Clear ();
			pick = true;
		}
	}
}