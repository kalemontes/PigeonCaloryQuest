using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnnemi : Spawn {

	public float L_speed;
	private int L_direction = -1;
	private float x;
	//public Spawn spawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}

	void Move(){
		x = L_direction * Time.deltaTime * L_speed;
		transform.Translate (x, 0, 0);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag =="DeathWall"){
			Debug.Log("collider with death wall");
			EnnemiMort ();
			gameObject.SetActive(false);
		}
		Debug.Log ("collider with trigger");
	}

	public void Reint(){
		gameObject.SetActive (true);
		transform.position = new Vector3(9.51f, Random.Range (0, 6000f) / 1000, -3.31f);
	}
}
