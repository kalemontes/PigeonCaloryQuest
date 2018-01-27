using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab;
    private ArrayList frontEnnemisAlive;
    private int nbMaxEnnemi;

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
}
