﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilEnnemi : Ennemi {
    public override void Reint()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollisionWithDeathWall(other);
        HandleCollisionWithPigeon(other);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
