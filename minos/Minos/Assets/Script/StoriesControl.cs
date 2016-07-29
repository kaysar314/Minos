using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[Serializable]
public class Stories {
	public sto[] storiesList;

	[Serializable]
	public struct sto{
		public sayings[] saying;
	}

	[Serializable]
	public struct sayings{
		public string whom;
		public string say;
	}
}

public class StoriesControl : MonoBehaviour
{
	public GameObject npc;
	public GameObject pl;

	public TextAsset stories;

	public int curSaying;
	public int storyNum;
	/*
	 * 当点击开始游戏，storyNum == 0；
	 * 当捡到枪械，storyNum == 1；
	 * 当捡到火把，storyNum == 2；
	 * 当捡到地图，storyNum == 3；
	 * 当打开宝箱拿到钥匙，storyNum == 4；
	 * 当插入两把钥匙出现密码锁，storyNum == 5；
	*/

	public bool first;
	public bool show;

	Stories myObject = new Stories ();

	// Use this for initialization
	void Start ()
	{
		first = true;
		show = false;
		storyNum = 0; 
		curSaying = 0;
		myObject = JsonUtility.FromJson<Stories>(stories.text);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (show && first) {
			GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().unLockM();
			Time.timeScale = 0;
			first = false;
			if (myObject.storiesList [storyNum].saying [0].whom == "NPC") {
				pl.SetActive (false);
				npc.SetActive (true);
				npc.GetComponentInChildren<Text> ().text = myObject.storiesList [storyNum].saying [0].say;
			} else if (myObject.storiesList [storyNum].saying [0].whom == "Player") {
				npc.SetActive (false);
				pl.SetActive (true);
				pl.GetComponentInChildren<Text> ().text = myObject.storiesList [storyNum].saying [0].say;
			}
		}
	}

	public void Click(){
		curSaying += 1;
		if (myObject.storiesList [storyNum].saying [curSaying].whom == "NPC") {
			pl.SetActive (false);
			npc.SetActive (true);
			npc.GetComponentInChildren<Text> ().text = myObject.storiesList [storyNum].saying [curSaying].say;
		} else if (myObject.storiesList [storyNum].saying [curSaying].whom == "Player") {
			npc.SetActive (false);
			pl.SetActive (true);
			pl.GetComponentInChildren<Text> ().text = myObject.storiesList [storyNum].saying [curSaying].say;
		}
		if (myObject.storiesList [storyNum].saying [curSaying].whom == "none") {
			npc.SetActive (false);
			pl.SetActive (false);
			GameObject.Find ("FPSController").GetComponent<FirstPersonController> ().LockM();
			Time.timeScale = 1;
			show = false;
			first = true;
			curSaying = 0;
		}
	}
}