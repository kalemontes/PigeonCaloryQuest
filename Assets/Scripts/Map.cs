using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    private const int MAX_FRONT_ENNEMIS = 3;
    private const int MAX_BACK_ENNEMIS = 1;
    private const int MAX_OBUS_ENNEMIS = 2;

    public GameObject prefabFront;
    public GameObject prefabBack;
    public GameObject prefabObus;
    public GameObject pigeon;
    public Slider progression;
    static public int difficulty = 0;
    private int distance;
    private float distanceParourue = 0;
    private int distancePerDifficulty = 56;
    private ArrayList frontEnnemisAlive;
    private ArrayList backEnnemiAlive;
    private ArrayList obusEnnemiAlive;

    private bool ennemi1 = false;
    private bool ennemi2 = false;
    private bool ennemi3 = false;

    void Awake()
    {
        difficulty += 1;
        Debug.Log("Current Dificulty : " + difficulty);
        FixDifficulty();
    }
    // Use this for initialization
    void Start()
    {
        frontEnnemisAlive = new ArrayList();
        backEnnemiAlive = new ArrayList();
        obusEnnemiAlive = new ArrayList();

        for (int indice = 0; indice < MAX_FRONT_ENNEMIS; indice++)
        {
            GameObject ennemiGO = Instantiate(prefabFront, new Vector3(0, 0, 0), Quaternion.identity);
            ennemiGO.SetActive(false);
            frontEnnemisAlive.Add(ennemiGO);
        }

        for (int indice = 0; indice < MAX_FRONT_ENNEMIS; indice++)
        {
            GameObject ennemiGO = Instantiate(prefabBack, new Vector3(0, 0, 0), Quaternion.identity);
            ennemiGO.SetActive(false);
            backEnnemiAlive.Add(ennemiGO);
        }

        for (int indice = 0; indice < MAX_FRONT_ENNEMIS; indice++)
        {
            GameObject ennemiGO = Instantiate(prefabObus, new Vector3(0, 0, 0), Quaternion.identity);
            ennemiGO.SetActive(false);
            obusEnnemiAlive.Add(ennemiGO);
        }

        InvokeRepeating("ActiverEnnemi", 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Avancer();
    }

    private void ActiverEnnemi()
    {
        if (ennemi1)
        {
            foreach (GameObject ennemiGO in frontEnnemisAlive)
            {
                if (!ennemiGO.activeSelf)
                {
                    Debug.Log("Apparition d'un nouveau ennemi : Mine");
                    ennemiGO.GetComponent<FrontEnnemi>().Reint();
                }
            }
        }

        if (ennemi2)
        {
            foreach (GameObject ennemiGO in backEnnemiAlive)
            {
                if (!ennemiGO.activeSelf)
                {
                    Debug.Log("Apparition d'un nouveau ennemi : Avion");
                    ennemiGO.GetComponent<BackEnnemi>().Reint();
                }
            }
        }

        if (ennemi3)
        {
            foreach (GameObject ennemiGO in obusEnnemiAlive)
            {
                if (!ennemiGO.activeSelf)
                {
                    Debug.Log("Apparition d'un nouveau ennemi : Obus");
                    ennemiGO.GetComponent<ObusEnnemi>().Reint();
                }
            }
        }
    }

    void Avancer()
    {
        distanceParourue += pigeon.GetComponent<PigeonMouvement>().GetSpeed() * Time.deltaTime;
        progression.value = (distanceParourue * 100f) / distance;
        if (distanceParourue >= distance)
        {
            switch(difficulty)
            {
                case 1:
                    SceneManager.LoadScene("Recompense 1");
                    break;
                case 2:
                    SceneManager.LoadScene("Recompense 2");
                    break;
                case 3:
                    SceneManager.LoadScene("Recompense 3");
                    break;
                default:
                    SceneManager.LoadScene("Credits");
                    break;
            }
            //SceneManager.LoadScene("Main_Scene");
        }
    }

    void FixDifficulty()
    {
        distance = distancePerDifficulty * difficulty;
        if (difficulty == 1)
        {
            ennemi1 = true;
        }
        if (difficulty == 2)
        {
            ennemi1 = true;
            ennemi2 = true;
        }
        if (difficulty == 3)
        {
            ennemi1 = true;
            ennemi2 = true;
            ennemi3 = true;
        }
    }
}
