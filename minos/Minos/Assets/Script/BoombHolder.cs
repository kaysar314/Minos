using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoombHolder : MonoBehaviour {

	public GameObject boombPre;
	public List<Transform> boomb;
	public float boombtime;
	public float nextboomb;

	public Player player;

	void Start () {
		boombtime = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		

		if (boomb != null){
			foreach(Transform b in boomb){
				if (b != null) {
					b.transform.Translate (Vector3.forward * 0.2f);
				}
			}
		}
	}
}
