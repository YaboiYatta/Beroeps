using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infinityScript : MonoBehaviour {

	public GameObject tile;
	public float distance;
	public float tussen; // voor de ruimte tussen de background
	public float Y;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "TileSpawner")
		{
			distance++;
			Destroy(other.gameObject);
		 
			Instantiate (tile, new Vector3(distance * tussen + 1, Y, -1),Quaternion.identity);
		}
	}
}
