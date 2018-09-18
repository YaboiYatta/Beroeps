using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisionscript : MonoBehaviour {

	public Rigidbody2D rb;

	public float PowerupTijdMush;
	public float MushMush;

	// Use this for initialization
	void Start () {
		PowerupTijdMush = 3f;
		MushMush = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (MushMush == 1){ 
			if (Input.GetMouseButtonDown(0))
		{
			rb.AddForce(new Vector2(75,100));
			Debug.Log("boosto");
		}
		}
	}

	IEnumerator GoldenMushPowerup()
	{
		Debug.Log("PowerupMushactivate");
		MushMush = 1;
		yield return new WaitForSeconds(PowerupTijdMush);
		MushMush = 0;
		Debug.Log("PowerupMushdeactivate");
		StopCoroutine(GoldenMushPowerup());
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Golden_Mush")
		{
			StartCoroutine (GoldenMushPowerup());
		}
		if (other.name == "Coin")
		{
			rb.AddForce(new Vector2(150, 100));
			//AddScore?
			Debug.Log("HITCOIN");
		}
		if (other.name == "BeachBall")
		{
			rb.AddForce(new Vector2(650, 650));

		}
		if (other.tag == "PowerupDebuff")
		{
			Destroy(other.gameObject);
		}
		if (other.name == "bulletbill_1"){
			rb.AddForce(new Vector2(-200,-100));
			Debug.Log("HITBB");
		}
	}
}
