using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCA : Ennemi {

	private int L_direction = 1;
	private float y;
	//public Spawn spawn;

	// Use this for initialization
	void Start()
	{
		
	}

	protected override void Move()
	{
		y = L_direction * Time.deltaTime * L_speed;
		transform.Translate(0, y, 0);
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
		/*PigeonMouvement pigeon = other.GetComponent<PigeonMouvement>();
		if (pigeon)
		{
			Debug.Log("Collission avec un pigeon, l'ennemi sera detruit");
			gameObject.SetActive(false);
		}*/
	}

	public void Reint()
	{
		gameObject.SetActive(true);
		transform.position = new Vector3(Random.Range(-10000f, 10000f) / 1000, 0, -4f);
	}
}
