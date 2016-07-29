using UnityEngine;
using System.Collections;

public class MonsterMove : MonoBehaviour {

	public NavMeshAgent agent { get; private set; } 
	public Transform target;

	public bool canMove;
	private Animator anim;
	private Player caesar;
	public float Speed = 0.01f;
	public float Move = 0f;
	public bool isMovingBack = false;
	public bool isAttack = false;
	public bool isDamaged = false;
	public bool isDead = false;

	public bool addScores =false;

	public int damagedTimes = 0;
//	public float waitTime; 

	public float redRate = 0.4f;
	private float redTime = 0.0f;


	public float damRate = 0.3f;
//	private float damTime = 0.0f;

	public bool isRed = false;

	void Start () {

		target = GameObject.Find ("FPSController").transform;
		agent = GetComponentInChildren<NavMeshAgent>();

		anim = GetComponent<Animator>();
		anim.SetFloat ("Move",Move);

		agent.updateRotation = true;
		agent.updatePosition = true;
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player"){
//			var rotationVector = other.gameObject.transform.rotation.eulerAngles;
//			rotationVector.y = 180 + rotationVector.y;
//			transform.rotation = Quaternion.Euler(rotationVector);
//			transform.LookAt(other.gameObject.transform.position);
			caesar = other.gameObject.GetComponent<Player> ();
			anim.SetFloat ("Move", -1f);
			anim.SetBool ("Attack", true);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player"){
			caesar = other.gameObject.GetComponent<Player> ();
		}
		if (other.gameObject.tag == "Bullet"){
			damagedTimes += 1;
			isDamaged = true;
		}
	}
	void OnTriggerExit(Collider other){
		caesar = null;

		if (other.gameObject.tag == "Player"){
			anim.SetBool ("Attack", false);
			anim.SetFloat ("Move", 3f);
		}
	}

	void attackCaesar(){
		if (caesar) {
			caesar.health -= 1;
			caesar.ScreenRed ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (target != null && !isRed && GameObject.Find ("FPSController").GetComponent<Player>().health < 100) {
			anim.SetFloat ("Move", 3f);
//			Vector3 pos = target.position;
//			pos.y = transform.position.y;
//			transform.LookAt(pos);
			agent.SetDestination (target.position);
		} else {
			anim.SetFloat ("Move", 0f);
		}
			
		

		if (anim.GetBool ("Damaged")) {
			anim.SetBool ("Damaged", false);
			isDamaged = false;
		}
//		AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo (0);
		Move = anim.GetFloat ("Move");

		if (isAttack) {
			anim.SetFloat ("Move", -1f);
			anim.SetBool ("Attack", true);
			anim.SetBool ("Damaged", false);
			anim.SetBool ("Dead", false);
		}
		if (isDamaged) {
			agent.SetDestination (transform.position);
			isRed = true;
			redTime = Time.time + redRate;
			ChangeColor (new Color (1, 0, 0, 1));
			anim.SetFloat ("Move", -1f);
			anim.SetBool ("Dead", false);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Damaged", true);
		} else if(isRed && Time.time > redTime) {
			isRed = false;
			ChangeColor (new Color (1, 1, 1, 1));
		}
		if (damagedTimes >= 5) {
			if (caesar && !addScores) {
				caesar.killEnemy += 1;
				addScores = true;
			}
			agent.SetDestination (transform.position);
			ChangeColor (new Color (1, 1, 1, 1));
			anim.SetFloat ("Move", -1f);
			anim.SetBool ("Dead", true);
			anim.SetBool ("Attack", false);
			anim.SetBool ("Damaged", false);
			Destroy (gameObject, 5f);
			target = null;
			(gameObject.GetComponent (typeof(BoxCollider)) as Collider).enabled = false;
			(gameObject.GetComponent (typeof(Collider)) as Collider).enabled = false;
		}
//		if (Input.GetKeyDown (KeyCode.W)) {
//			anim.SetBool ("Dead", false);
//			anim.SetBool ("Attack", false);
//			anim.SetBool ("Damaged", false);
//			if (Move >= 0 && Move <= 2) {
//				anim.SetFloat ("Move", Move + 1f);
//			} else {
//				anim.SetFloat ("Move", 0);
//			}
//		}
	}

	void ChangeColor(Color color){
		foreach(Renderer r in GetComponentsInChildren<Renderer>()){
			r.material.color= color;
		}
	}

	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}