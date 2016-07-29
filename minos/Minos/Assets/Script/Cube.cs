using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	[SerializeField] private AudioClip m_Boom;

	public float DestroyTime = 2.0f;
	public GameObject boomPrefab;
	public GameObject Cub;
	public bool isIn;
	private AudioSource m_AudioSource;
	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet"){
			GameObject boom = (GameObject)Instantiate(boomPrefab);
			boom.transform.position = transform.position;
			boom.transform.rotation = transform.rotation;
			PlayBoomSound ();
			boom.SetActive (true);
			Destroy (Cub, DestroyTime);
			Cub.SetActive (false);
		}
	}
	void PlayBoomSound()
	{
		m_AudioSource.clip = m_Boom;
		m_AudioSource.Play();
	}
}