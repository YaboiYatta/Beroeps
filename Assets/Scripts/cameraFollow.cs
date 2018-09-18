using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraFollow : MonoBehaviour {

	public Transform target;
	public  Text Text;
	public static float score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		score = Mathf.Round(target.position.x + 5.1f);
		Text.text = "Distance: " + score ;

		if (frisbeeLaunch.isLaunched)
		{
		if (target.position.y <= 0)
		{
		transform.position = new Vector3(target.position.x + 5f, 0, target.position.z - 10f);
		}
		else
		{
		if (target.position.y >= 30)
		{
		transform.position = new Vector3(target.position.x + 5f, 30, target.position.z - 10f);
		}
		else
		{
		transform.position = new Vector3(target.position.x + 5f, target.position.y, target.position.z - 10f);
		}
		}
		}
		else
		{
		transform.position = new Vector3(0, 0, target.position.z - 10f);
		}
		 
	}
	
}
