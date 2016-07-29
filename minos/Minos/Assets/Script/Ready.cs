using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ready : MonoBehaviour {

	[System.Serializable]
	public class MapInfo {

		[System.Serializable]
		public struct pos {
			public int x;
			public int y;
			public int num;
		}

		public pos[] infos;
		public pos[] infos1;
		public pos[] infos4;
		public pos[] infos7;
		public pos[] infos3;
		public pos[] enemyBotInfos;
	}

	public List<GameObject> walls;
	public GameObject player;
	public GameObject darkroom;
	public GameObject darkroom2;
	public List<GameObject> enemyBots;
	public GameObject enemyBotKey;
	public GameObject tresureBox;
	public GameObject goldKey;
	public GameObject greyKey;
	public GameObject silverKey;
	public GameObject torch;
	public GameObject gun;
	public GameObject map;

	public GameObject EnemyBotKeyPrefab;
	public GameObject GunPrefab;
	public GameObject MapPrefab;
	public GameObject TorchPrefab;
	public GameObject GreyKeyPrefab;
	public GameObject GoldKeyPrefab;
	public GameObject TresureBoxPrefab;
	public GameObject EnemyBotPrefab;
	public GameObject DarkroomPrefab;
	public GameObject DarkroomPrefab2;
	public GameObject WallPrefab;
	public GameObject WallPrefab_1;
	public GameObject WallPrefab_4;
	public GameObject WallPrefab_7;
	public GameObject WallPrefab_3;

	public Transform Guninit;

	public TextAsset wallPos;
	private MapInfo mapinfo = new MapInfo ();
	private string infoJson;

	void Start () {
		infoJson = wallPos.text;
		mapinfo = JsonUtility.FromJson<MapInfo>(infoJson);
		SetWall ();
		SetEnemyBots ();
		darkroom = (GameObject)Instantiate(DarkroomPrefab);
		darkroom2 = (GameObject)Instantiate(DarkroomPrefab2);
		tresureBox = (GameObject)Instantiate(TresureBoxPrefab);
		goldKey = (GameObject)Instantiate(GoldKeyPrefab);
		greyKey = (GameObject)Instantiate(GreyKeyPrefab);
		torch = (GameObject)Instantiate(TorchPrefab);
		gun = (GameObject)Instantiate(GunPrefab);
		Guninit = gun.transform;
		map = (GameObject)Instantiate(MapPrefab);
		enemyBotKey = (GameObject)Instantiate(EnemyBotKeyPrefab);
		silverKey = GameObject.Find ("key_silver");
		init ();
	}

	public void init(){
		enemyBotKey.SetActive (true);
		enemyBotKey.GetComponentInChildren<BotDamkey> ().health = 5;
		enemyBotKey.transform.position = new Vector3 (81.3f,0.433f,9.95f);
		enemyBotKey.transform.parent = null;
		silverKey.transform.SetParent (enemyBotKey.transform);
		silverKey.transform.localPosition = new Vector3 (0,0.66f,0);
		silverKey.GetComponent<SilverKey> ().init ();
		greyKey.transform.position = new Vector3 (62,0.1f,134);
		greyKey.transform.parent = null;
		greyKey.GetComponent<GreyKey> ().init ();
		torch.transform.position = new Vector3 (14.557f,1.852f,161.8f);
		torch.transform.parent = null;
		torch.GetComponent<Torch> ().init ();
		gun.transform.position = new Vector3 (45.1f,0.044f,60.9f);
		gun.transform.parent = null;
		gun.GetComponent<Gun> ().init ();
		gun.GetComponentInChildren<Bullet> ().bullSum = 20;
		map.SetActive (true);
		goldKey.transform.position = new Vector3 (30,0.5f,59);
		goldKey.transform.parent = null;
		goldKey.GetComponent<GoldKey> ().init ();
		int i = 0;
		foreach (GameObject e in enemyBots) {
			e.GetComponentInChildren<BotDam> ().health = 5;
			e.transform.position = new Vector3 (mapinfo.enemyBotInfos[i].x*6, 0.4f, mapinfo.enemyBotInfos[i].y*6);
			e.SetActive (true);
			i += 1;
		}
		player.GetComponent<Player>().init ();
		player.transform.position = new Vector3 (0f, 1f, 0f);
	}

	void SetEnemyBots(){
		foreach(MapInfo.pos pos in mapinfo.enemyBotInfos){
			for (int i = 0; i < pos.num; i++) {
				GameObject enemyBot = (GameObject)Instantiate(EnemyBotPrefab);
				enemyBot.transform.position = new Vector3 (pos.x*6, 0.4f, pos.y*6);
				enemyBot.transform.SetParent (transform);
				enemyBots.Add (enemyBot);
			}
		}
	}

	void SetWall(){
		foreach(MapInfo.pos pos in mapinfo.infos){
			for (int i = pos.y; i <= pos.num; i++) {
				GameObject wall = (GameObject)Instantiate(WallPrefab);
				wall.transform.position = new Vector3 (pos.x*6, 3, i*6);
				wall.transform.SetParent (transform);
				walls.Add (wall);
			}
		}
		foreach(MapInfo.pos pos in mapinfo.infos1){
			for (int i = pos.y; i <= pos.num; i++) {
				GameObject wall = (GameObject)Instantiate(WallPrefab_1);
				wall.transform.position = new Vector3 (pos.x*6, 3, i*6);
				wall.transform.SetParent (transform);
				walls.Add (wall);
			}
		}
		foreach(MapInfo.pos pos in mapinfo.infos4){
			for (int i = pos.y; i <= pos.num; i++) {
				GameObject wall = (GameObject)Instantiate(WallPrefab_4);
				wall.transform.position = new Vector3 (pos.x*6, 3, i*6);
				wall.transform.SetParent (transform);
				walls.Add (wall);
			}
		}
		foreach(MapInfo.pos pos in mapinfo.infos7){
			for (int i = pos.y; i <= pos.num; i++) {
				GameObject wall = (GameObject)Instantiate(WallPrefab_7);
				wall.transform.position = new Vector3 (pos.x*6, 3, i*6);
				wall.transform.SetParent (transform);
				walls.Add (wall);
			}
		}
		foreach(MapInfo.pos pos in mapinfo.infos3){
			for (int i = pos.y; i <= pos.num; i++) {
				GameObject wall = (GameObject)Instantiate(WallPrefab_3);
				wall.transform.position = new Vector3 (pos.x*6, 3, i*6);
				wall.transform.SetParent (transform);
				walls.Add (wall);
			}
		}
	}
}