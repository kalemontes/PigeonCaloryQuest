using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackEnnemi : Ennemi
{
	private int L_direction = 1;
	private float x;
	//public Spawn spawn;

	// Use this for initialization
	void Start()
	{

	}

    public override void Move()
	{
		x = L_direction * Time.deltaTime * speed;
		transform.Translate(x, 0, 0);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "DeathWall")
		{
			gameObject.SetActive(false);
			Debug.Log("Collission avec le DeathWall, l'ennemi sera detruit");
			//TODO: Pas besoin d'appeler EnnemiMort() car notre condition de mort repose sur le fait que l'objet est inactif;
			//TODO: ou soit on cree une fonction EnnemiMort au sein de la class Ennemi
		}
		PigeonMouvement pigeon = other.GetComponent<PigeonMouvement>();
		if (pigeon)
		{
			Debug.Log("Collission avec un pigeon, l'ennemi sera detruit");
			gameObject.SetActive(false);
		}
	}

	public override void Reint()
	{
		gameObject.SetActive(true);
		transform.position = new Vector3(-10f, Random.Range(0, 6000f) / 1000, -4f);
	}
}
