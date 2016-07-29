using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBullet : MonoBehaviour {

	[SerializeField] private AudioClip m_Shoot;
	private AudioSource m_AudioSource;

	public GameObject bulletPrefab;
	public List<Transform> bullet;
	public float DestroyTime = 2.0f;
	public float bulletTime = 0;
	public GameObject enemy;

	public float findDist;

	public Transform PlayerTrans;

	public float rHit;

	public bool canShoot;

	public float shootTime;
	public float nextShootTime;

	public float bulletSpeed;

	void Start () {
		canShoot = true;
		m_AudioSource = GetComponent<AudioSource>();
		PlayerTrans = GameObject.Find ("FPSController").transform;
		gameObject.GetComponentInParent<BotMove> ().findout = false;
	}

//	void OnTriggerStay(Collider other){
//		
//		if (other.gameObject.tag == "Player" && canShoot) {
//			Vector3 pos = other.gameObject.transform.position;
////			transform.LookAt (pos.x, transform.position.y, pos.z);
//			RaycastHit[] hits = Physics.RaycastAll (this.transform.position, (pos - this.transform.position).normalized);
//			bool obs = false;
//			foreach (RaycastHit hit in hits) {
//				if (hit.collider.tag == "Wall") {
//					obs = false;
//					break;
//				}
//				if (hit.collider.tag == "Player") {
//					obs = true;
//					break;
//				}
//			}
//			if (Time.time > nextShootTime && obs) {
//				//enemy shoot
//				GameObject bul = (GameObject)Instantiate(bulletPrefab);
//				bul.transform.position = transform.position;
//				bul.transform.LookAt (new Vector3(rand(pos.x),rand(pos.y),rand(pos.z)));//add random shoot error
//				bullet.Add (bul.transform);
//				PlayShootSound ();
//				Destroy (bul, DestroyTime);
//				bulletTime = Time.time + DestroyTime;
//				nextShootTime = Time.time + shootTime;
//			}
//		}
//	}

	void Update () {

		if (Time.time > nextShootTime && canShoot) {
			float dist = Vector3.Distance (PlayerTrans.position, transform.position);
			if(dist < findDist){
				Debug.Log ("in dist");
				RaycastHit[] hits = Physics.RaycastAll (this.transform.position, (PlayerTrans.position - this.transform.position).normalized,dist);
				bool obs = true;
				foreach (RaycastHit hit in hits) {
					if (hit.collider.tag == "Wall") {
						obs = false;
						break;
					}
				}
				if (obs) {
					gameObject.GetComponentInParent<BotMove> ().findout = true;
					Shoot ();
				} else {
					gameObject.GetComponentInParent<BotMove> ().findout = false;
				}
			} else {
				gameObject.GetComponentInParent<BotMove> ().findout = false;
			}
		}
		if (bullet != null){
			foreach(Transform b in bullet){
				if (b != null) {
					b.transform.Translate (Vector3.forward * bulletSpeed);
				}
			}
		}
		if (Time.time > bulletTime && bullet.Count > 0) {
			bullet.RemoveAt(0);
		}
	}

	void Shoot(){
		//enemy shoot
		GameObject bul = (GameObject)Instantiate(bulletPrefab);
		bul.transform.position = transform.position;
		bul.transform.LookAt (new Vector3(rand(PlayerTrans.position.x),PlayerTrans.position.y,rand(PlayerTrans.position.z)));//add random shoot error
		bullet.Add (bul.transform);
		PlayShootSound ();
		Destroy (bul, DestroyTime);
		bulletTime = Time.time + DestroyTime;
		nextShootTime = Time.time + shootTime;
	}

	void PlayShootSound()
	{
		m_AudioSource.clip = m_Shoot;
		m_AudioSource.Play();
	}

	public float rand(float num){
		return (num + (rHit * (Random.Range(-1.4f, 1.4f)*Random.Range(-1.4f, 1.4f))));
	}
}