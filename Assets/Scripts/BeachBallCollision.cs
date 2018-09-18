using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBallCollision : MonoBehaviour {

	Animator Animator;

	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Frisbee")
		{
			Animator.Play("Hit");
		}
	}
}
