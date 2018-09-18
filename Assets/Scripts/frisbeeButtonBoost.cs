using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class frisbeeButtonBoost : MonoBehaviour {

	public Rigidbody2D rb;

	public float ButtonCooldown;
	public float ButtonBoost;
	public Button Button;

	// Use this for initialization
	void Start () {
		ButtonBoost = 1;
		Button.interactable = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ButtonClick(){
			rb.AddForce(new Vector2(400,600));
			Debug.Log("BOOSTO!");
			StartCoroutine(ButtonCd());
	}

	IEnumerator ButtonCd(){
		Button.interactable = false;
		yield return new WaitForSeconds(ButtonCooldown);
		Button.interactable = true;
	}
}
