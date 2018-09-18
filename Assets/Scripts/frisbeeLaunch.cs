using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbeeLaunch : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public TrailRenderer trail;

	public static bool isLaunched = false;

	public float releaseTime = 0.15f;
	public float maxDistance = 2.5f;
	public float hookLocation = -5f;

	private bool isPressed = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLaunched)
		{
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (mousePos.x >= -5.16)
			{
				mousePos.x = -5;
			}
			else
			{
			
			if (Vector3.Distance(mousePos, hook.position) > maxDistance)
			{
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDistance;
			}
			else
			{
				rb.position = mousePos;
			}
			}
		}
		}
	}
	
	
	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}
	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;
		
		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		GetComponent<SpringJoint2D>().enabled = false;
		isLaunched = true;
	}
	
}
