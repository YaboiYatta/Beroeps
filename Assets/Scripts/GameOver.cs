using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject GameOverCanvas;
	public GameObject ScoreCanvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.x == 0){
			if (frisbeeLaunch.isLaunched == true){
			ScoreCanvas.SetActive(false);
			GameOverCanvas.SetActive(true);
			}
		}
	}
}
