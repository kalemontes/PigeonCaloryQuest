using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnnemi : IAEnnemi
{

	private int L_direction = -1;
	private float x;
	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "DeathWall"){
			gameObject.SetActive(false);
		}

        PigeonMouvement pigeon = other.GetComponent<PigeonMouvement>();
        if(pigeon){
            Debug.Log("Collission avec un pigeon, l'ennemi sera detruit");
            gameObject.SetActive(false);
        }
    }

    protected override void Move(){
        x = L_direction * Time.deltaTime * L_speed;
        transform.Translate(x, 0, 0);
    }
}
