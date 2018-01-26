using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnnemi : MonoBehaviour {

	public float L_speed;
	private int L_direction = -1;
	private float x;
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
			gameObject.SetActive(false);
		}
	}
}
