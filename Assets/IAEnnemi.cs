using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAEnnemi : MonoBehaviour {

    public float L_speed;
    public float calories;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        Move();
    }

    protected abstract void Move();

}
