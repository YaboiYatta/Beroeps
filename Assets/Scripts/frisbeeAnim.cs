using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frisbeeAnim : MonoBehaviour {

	public Sprite[] animationList;
	private float animatie;
	private float spriteCounter = 0;
	private float spriteStop;

	// Use this for initialization
	void Start () {
		animatie = 0.3f;
		StartCoroutine (spin());
		spriteStop = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator spin()
	{
		yield return new WaitForSeconds(animatie);
		if (spriteCounter == 0)
		{
		this.GetComponent<SpriteRenderer> ().sprite = animationList [1];
		spriteCounter = 1;
		}
		else
		{
			this.GetComponent<SpriteRenderer> ().sprite = animationList [0];
			spriteCounter = 0;
		}
		if (spriteStop == 0)
		{ 
		StartCoroutine (spin());
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "Floor")
		{
			spriteStop = 1;
			StopCoroutine(spin());
		}
	}
}
