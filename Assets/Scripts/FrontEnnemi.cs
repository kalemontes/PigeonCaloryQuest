using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnnemi : Ennemi
{
    private int L_direction = -1;
    private float x;
    //public Spawn spawn;

    // Use this for initialization
    void Start()
    {

    }

    protected override void Move()
    {
        x = L_direction * Time.deltaTime * L_speed;
        transform.Translate(x, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeathWall")
        {
            gameObject.SetActive(false);
            Debug.Log("collider with death wall");
            //TODO: Pas besoin d'appeler EnnemiMort() car notre condition de mort repose sur le fait que l'objet est inactif;
        }
        PigeonMouvement pigeon = other.GetComponent<PigeonMouvement>();
        if (pigeon)
        {
            Debug.Log("Collission avec un pigeon, l'ennemi sera detruit");
            gameObject.SetActive(false);
        }
    }

    public void Reint()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(9.51f, Random.Range(0, 6000f) / 1000, -3.31f);
    }
}
