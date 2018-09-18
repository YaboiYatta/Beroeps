using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	public Text Distance;
	public Text ScoreScore;
	public Transform target;
	public GameObject GameOverCanvas;

	// Use this for initialization
	void Start () {
		Distance.text = "DistanceStartText";
		ScoreScore.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		Distance.text = Mathf.Round(target.position.x + 5.1f) + " Meters!";
	}

	public void Retry(){
		frisbeeLaunch.isLaunched = false;
		GameOverCanvas.SetActive(false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		 
	}

	public void Shop(){
		SceneManager.LoadScene("Shop");
	}

	public void Menu(){
		SceneManager.LoadScene("Main Menu");
	}
}
