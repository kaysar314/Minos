
using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]  

public class MineBot: MonoBehaviour {

	public NavMeshAgent agent; 
	protected Animator avatar;
//	public Player player;
	public GameObject obj;
	public float DirectionDampTime = .25f;

	void Start () 
	{
		avatar = GetComponent<Animator>();

	}
    
	void Update () 
	{
		agent.SetDestination (new Vector3( obj.transform.position.x,transform.position.y,obj.transform.position.z));
		if(avatar)
		{
            bool j = Input.GetButton("Fire1");
      		float h = Input.GetAxis("Horizontal");
        	float v = Input.GetAxis("Vertical");
			
			avatar.SetFloat("Speed", h*h+v*v);
            avatar.SetFloat("Direction", Mathf.Atan2(h,v) * 180.0f / 3.14159f);
//            avatar.SetBool("Jump", j);

		    Rigidbody rigidbody = GetComponent<Rigidbody>();

//            if(rigidbody)
//            {
//                Vector3 speed = rigidbody.velocity;
//                speed.x = 4 * h;
//                speed.z = 4 * v;
//                rigidbody.velocity = speed;
//                if (j)
//                {
//                    rigidbody.AddForce(Vector3.up * 20);
//                }
//            }
		}		
	}   		  
}
