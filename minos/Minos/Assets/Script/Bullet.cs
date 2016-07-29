using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {

	public Player player;

	[SerializeField] private AudioClip m_Shoot;
	private AudioSource m_AudioSource;

	public GameObject bulletPrefab;
	public List<Transform> bullet;
	public float DestroyTime = 2.0f;
	public float bulletTime = 0;
	public Gun gunScript;
	private GameObject gun;

	public int bullSum;

	public float nextNar;
	public float NarCoolingTime;

	public float bulletSpeed = 5.0f;

	void Start () {

		bullSum = 20;
		player = GameObject.Find ("FPSController").GetComponent<Player> ();
		m_AudioSource = GetComponent<AudioSource>();
//		gun = GameObject.Find ("Gun");
		gunScript = gameObject.GetComponentInParent<Gun>();

		nextNar = 0;
		NarCoolingTime = 4f;
	}

	void OnGUI(){
		if (gunScript.hasGun) {
			GUI.Button (new Rect (Screen.width - 150, 110, 100, 20), "Ammo : " + bullSum );
		}
	}

	void Update () {
		
		if (bullet != null){
			foreach(Transform b in bullet){
				if (b != null) {
					if (b.localScale.x == 1.4f) {
						b.transform.Translate (Vector3.forward * bulletSpeed / 1.2f);
					} else if (b.localScale.x == 4f) {
						b.transform.Translate (Vector3.forward * bulletSpeed / 1.5f);
					} else {
						b.transform.Translate (Vector3.forward * bulletSpeed);
					}
				}
			}
		}

		if (Time.time > bulletTime && bullet.Count > 0) {
			bullet.RemoveAt(0);
		}

		if (Input.GetKeyUp(KeyCode.Mouse0) && gunScript.hasGun){
			if (bullSum > 0) {
				bullSum -= 1;
				GameObject bul = (GameObject)Instantiate (bulletPrefab);
				bul.transform.position = transform.position;
				bul.transform.rotation = transform.rotation;
				bullet.Add (bul.transform);
				PlayShootSound ();
				//			projectile.transform.Translate (Vector3.forward * 1);
				Destroy (bul, DestroyTime);
				bulletTime = Time.time + DestroyTime;
			} else {
				
			}
		}
	}

	void PlayShootSound()
	{
		m_AudioSource.clip = m_Shoot;
		m_AudioSource.Play();
	}
}