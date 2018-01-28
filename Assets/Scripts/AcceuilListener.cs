using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceuilListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Tutorial");
		}
		if ((Input.GetKey (KeyCode.LeftShift))||(Input.GetKey (KeyCode.RightShift))) {
			SceneManager.LoadScene ("Main_Scene");
		}
	}


}
