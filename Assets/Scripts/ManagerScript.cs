using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour {

//Highscore**
	public Text highScore;
	public Transform target;
	public int distancescore;
	public int getdistancescore;
//Highscore**

// Use this for initialization
	void Start () {
		//Highscore**
		highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
		//Highscore**
	}
	
	// Update is called once per frame
	void Update () {
		//Highscore**
		getdistancescore = Mathf.RoundToInt(target.position.x + 5.1f);
		distancescore = getdistancescore;

		if (distancescore > PlayerPrefs.GetInt("Highscore"))
			{
			PlayerPrefs.SetInt("HighScore", distancescore);
			highScore.text = "Highscore: " + distancescore + " Meters!";		
		}
		//Highscore**
	}
}
