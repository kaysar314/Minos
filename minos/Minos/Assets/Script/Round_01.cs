using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Round_01 : MonoBehaviour {

	// world x0 = -72.456 , z0 = -78.594 ; x1 = 72.456 , z1 = 78.594

	public GameObject motherEnemy;
	public float enemyBornTime;
	public float nextEnemyTime;
	public GameObject player;
	public int totalEnemy;
	private int currentEnemy;
	public List<GameObject> enemys;

	public GameObject myPos;
	public GameObject enemyPos;

	public GameObject enemyCount;
	private int eneCount;
	public Text text;

	public List<GameObject> enemyp;
	private GameObject myp;

	public GameObject map;

	void Start () {
		text = enemyCount.GetComponent<Text> ();

		myp = (GameObject)Instantiate(myPos);
		myp.transform.SetParent (map.transform);
		myp.transform.localPosition = new Vector3(player.transform.position.x,player.transform.position.z,0);
		currentEnemy = 0;
		eneCount = 0;
		enemyBornTime = 1f;
		nextEnemyTime = 0;
		totalEnemy = 5;

	}

	void Update () {
		text.text = "Enemys : " + eneCount;

		if (Time.time > nextEnemyTime && currentEnemy <= totalEnemy){

			GameObject enemy = (GameObject)Instantiate (motherEnemy);
			GameObject enp = (GameObject)Instantiate (enemyPos);

			Vector3 pos = enemy.transform.localPosition;
			enemy.transform.localPosition = new Vector3 (pos.x - (int)Random.Range (-30, 30), pos.y, pos.z - (int)Random.Range (-30, 30));

			enp.transform.SetParent (map.transform);
			enp.transform.localPosition = new Vector3(enemy.transform.localPosition.x,enemy.transform.localPosition.z,0);
			enemyBornTime = Random.Range(0,2f);
			nextEnemyTime = Time.time + enemyBornTime;
			currentEnemy += 1;
			eneCount += 1;
			enemys.Add (enemy);
			enemyp.Add (enp);
		}

		if (enemyp.Count > 0){
			for (int i = 0; i < enemyp.Count; i++) {
				if (enemys [i]) {
					enemyp [i].transform.localPosition = new Vector3 (enemys [i].transform.localPosition.x, enemys [i].transform.localPosition.z, 0);
				} else {
					if (enemyp [i]) {
						eneCount -= 1;
					}
					Destroy(enemyp[i],0);
				}
			}
		}

		myp.transform.localPosition = new Vector3(player.transform.position.x,player.transform.position.z,0);
	}
}