using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ButtonControl : MonoBehaviour {
	public Button start;
	public Button help;
	public Button helpdetail;
	public GameObject HD;
	public GameObject player;
	public FirstPersonController fpc;

	// Use this for initialization
	void Start () {
		fpc = player.GetComponent<FirstPersonController> ();

		fpc.unLockM ();
		HD.SetActive(false);
//		start.onClick.AddListener(delegate() {
//			this.StartGame(); 
//		});
//
//		helpdetail.onClick.AddListener(delegate() {
//			this.GetDetail(); 
//		});
//
//		help.onClick.AddListener(delegate() {
//			this.GetHelp(); 
//		});
	}

	public void StartGame () {
		gameObject.SetActive (false);
		fpc.LockM ();
		GameObject.Find ("Stories").GetComponent<StoriesControl> ().storyNum = 0;
		GameObject.Find ("Stories").GetComponent<StoriesControl> ().show = true;
	}

	public void GetHelp () {
		HD.SetActive(true);
	}

	public void GetDetail () {
		HD.SetActive(false);
	}

	void OnClick(){
		
	}
}
