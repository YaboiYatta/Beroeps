using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatie : MonoBehaviour {


	public Sprite[] animationList;
	private float animatie;
	private float spriteCounter = 0;

	// Use this for initialization
	void Start () {
		animatie = 0.1f;
		StartCoroutine (spin());
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
		StartCoroutine (spin());
	}
}
