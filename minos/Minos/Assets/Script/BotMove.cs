
using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))]  

public class BotMove: MonoBehaviour {

	public NavMeshAgent agent; 
	public Animator avatar;
	public Player player;
	public GameObject obj;
	public float DirectionDampTime = .25f;
	public GameObject boom;

	public bool findout;
	public Vector3 pos;
	public bool attack;
	public bool canMove;

	void Start () 
	{
		findout = false;
		pos = transform.position;
		canMove = false;
//		avatar = GetComponentInChildren<Animator>();
		obj = GameObject.Find ("FPSController");
		player = obj.GetComponent<Player> ();
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = true;
		agent.updatePosition = true;
//		agent.SetDestination (pos);
	}

	void Update () 
	{
		if(findout && agent){
			agent.SetDestination (obj.transform.position);
		}
		if(!findout){
//			agent.SetDestination (pos);
		}
		float h = 0;
		float v = 0;
//		agent.SetDestination (obj.transform.position);
		if(avatar  && agent)
		{
			if (agent.remainingDistance > 7f && agent) {
				h = 0;
				v = 1;
			} else {
				h = 0;
				v = 0;
			}
			avatar.SetFloat("Speed", h*h+v*v);
			avatar.SetFloat("Direction", Mathf.Atan2(h,v) * 180.0f / 3.14159f);
		}		
	}   		  
}
