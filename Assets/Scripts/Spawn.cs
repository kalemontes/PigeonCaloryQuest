using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject prefab;
	private GameObject[] frontEnnemi;
	private int nbMaxEnnemi;
	private int nbEnnemiEnVie;
	private int indice;
	// Use this for initialization


	void Start () {
		//Vector3 pos = spawn.transform.position;
		nbMaxEnnemi = 3;
		nbEnnemiEnVie = 0;
		frontEnnemi = new GameObject[nbMaxEnnemi];
		for (indice = 0; indice < nbMaxEnnemi; indice++) {
			frontEnnemi [indice] = Instantiate (prefab, new Vector3(0, 0, 0), Quaternion.identity);
			frontEnnemi [indice].gameObject.SetActive (false);
		}
		indice = 0;
		InvokeRepeating ("ActiverEnnemi", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
	}

	private void ActiverEnnemi(){
		if (nbEnnemiEnVie <= nbMaxEnnemi) {
			if (indice < frontEnnemi.Length) {
				frontEnnemi [indice].GetComponent<FrontEnnemi> ().Reint ();
				Debug.Log ("apparition de l'ennemi " + frontEnnemi[indice]);
				nbEnnemiEnVie++;
				indice++;
			} else {
				indice = 0;
			}
		}
	}

	public void EnnemiMort(){
		nbEnnemiEnVie--;
		Debug.Log ("ennemi tué");
	}
}
