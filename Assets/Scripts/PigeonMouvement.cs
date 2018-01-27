using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMouvement : MonoBehaviour
{

    public float speed;
    public float weight;
    private float y;

    // Use this for initialization
    void Start()
    {
        //TODO: rotater = GameObject.Find("Cube"); comprendre ce que ça fait ??
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, y, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Une collision avec quelque chose");
        bool didCollideWithEnnemi = handleCollisionWithFrontEnnemi(other);
        if(didCollideWithEnnemi)
        {
            applyScaledWeight();
        }
    }

    private bool handleCollisionWithFrontEnnemi(Collider other)
    {
        bool didHandle = false;
        FrontEnnemi ennemi = other.GetComponent<FrontEnnemi>();
        if (ennemi)
        {
            Debug.Log("Collision avec un FrontEnnemi detectée");
            Debug.Log("Le pigeon prendra un poid de + " + ennemi.calories);
            this.weight += ennemi.calories;
            didHandle = true;
        }
        return didHandle;
    }

    private void applyScaledWeight()
    {
        //TODO: faire l'echelle en fonction du poids du pigeon
        gameObject.transform.localScale = new Vector3(2, 2, 1);
    }
}
