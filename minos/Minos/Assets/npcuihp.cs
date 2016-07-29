using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npcuihp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Camera.main.transform.rotation;
	}
}
