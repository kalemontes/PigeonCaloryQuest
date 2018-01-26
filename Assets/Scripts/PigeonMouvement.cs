using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMouvement : MonoBehaviour {

	public float L_speed;
	private float y;
	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		Move ();
	}

	private void Move(){
		y = Input.GetAxis ("Vertical") * Time.deltaTime * L_speed;
		transform.Translate (0, y, 0);
	}
}
