using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    public GameObject prefab;
	public GameObject pigeon;
	public Slider progression;
	static public int difficulty = 0;
	private int distance;
	private float distanceParourue = 0;
	private int distancePerDifficulty = 56;
    private ArrayList frontEnnemisAlive;
    private int nbMaxEnnemi;

	void Awake(){
		difficulty += 1;
		FixDifficulty ();
	}
    // Use this for initialization
    void Start()
    {
        //Vector3 pos = spawn.transform.position;
        nbMaxEnnemi = 3;
        frontEnnemisAlive = new ArrayList();
        for (int indice = 0; indice < nbMaxEnnemi; indice++)
        {
            GameObject ennemiGO = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            ennemiGO.SetActive(false);
            frontEnnemisAlive.Add(ennemiGO);
        }
        InvokeRepeating("ActiverEnnemi", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
		Avancer ();
    }

    private void ActiverEnnemi()
    {
        foreach(GameObject ennemiGO in frontEnnemisAlive)
        {
            if(!ennemiGO.activeSelf)
            {
                Debug.Log("Apparition d'un nouveau ennemi");
                ennemiGO.GetComponent<FrontEnnemi>().Reint();
            }
        }
    }

    public void EnnemiMort(Ennemi ennemi)
    {
        ennemi.gameObject.SetActive(false);
        Debug.Log("Ennemi tué");
    }

	void Avancer(){
		distanceParourue += pigeon.GetComponent<PigeonMouvement> ().GetSpeed () * Time.deltaTime;
		progression.value = (distanceParourue * 100f) / distance;
		if (distanceParourue >= distance) {
			SceneManager.LoadScene ("Main_Scene");
		}
	}

	void FixDifficulty(){
		distance = distancePerDifficulty * difficulty;
		if (difficulty > 3) {
			SceneManager.LoadScene ("");
		}
	}
}
