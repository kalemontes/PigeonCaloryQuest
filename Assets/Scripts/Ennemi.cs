using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemi : MonoBehaviour
{

    public float speed;
    public int calories;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    public abstract void Move();
    public abstract void Reint();

    protected bool HandleCollisionWithDeathWall(Collider other)
    {
        bool didHandleColission = false;
        if (other.tag == "DeathWall" || other.tag == "Ground")
        {
            gameObject.SetActive(false);
            Debug.Log("Collission avec le DeathWall, l'ennemi sera detruit");
            didHandleColission = true;
        }
        return didHandleColission;
    }

    protected bool HandleCollisionWithPigeon(Collider other)
    {
        bool didHandleColission = false;
        PigeonMouvement pigeon = other.GetComponent<PigeonMouvement>();
        if (pigeon)
        {
            Debug.Log("Collission avec un pigeon, l'ennemi sera detruit");
            gameObject.SetActive(false);
            didHandleColission = true;
        }
        return didHandleColission;
    }
}
