using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonMouvement : MonoBehaviour
{
    private const int STANDARD_WEIGHT = 350;    //360 grammes est le poid standard pour un pigeon biset
    private const int MAX_WEIGHT = 500;
    private const int MAX_GAIN_WEIGHT = MAX_WEIGHT - STANDARD_WEIGHT;
    private const int MAX_SCALE_LEVELS = 5;
    private const float SCALE_WEIGHT_FACTOR = 0.5f;
    private const int WEIGHT_LOOSE_FACTOR = 5;  // nombre de grammes perdus par le pigeon à chaque effort

    private Vector3 initialScale;

    public float speed;
    public float weight;
    int currrentWeightLevel;

    private float y;

    // Use this for initialization
    void Start()
    {
        //TODO: rotater = GameObject.Find("Cube"); comprendre ce que ça fait ??
        initialScale = gameObject.transform.localScale;
        weight = STANDARD_WEIGHT;
        currrentWeightLevel = 0;

        InvokeRepeating("ApplyWeightLose", 5.0f, 5.0f);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Fly();
        Sprint();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Une collision avec quelque chose");
        bool didCollideWithEnnemi = HandleCollisionWithFrontEnnemi(other);
        if (didCollideWithEnnemi)
        {
            //TODO: quelque chose ici ?
        }
    }

    private bool HandleCollisionWithFrontEnnemi(Collider other)
    {
        bool didHandle = false;
        FrontEnnemi ennemi = other.GetComponent<FrontEnnemi>();
        if (ennemi)
        {
            //Debug.Log("Collision avec un FrontEnnemi detectée");
            ApplyWeightGain(ennemi.calories);
            didHandle = true;
        }
        return didHandle;
    }

    #region Metier

    private void ApplyScaledWeight()
    {
        // Si j'ai le poids max j'ai comme meme le droit de perdre du poids
        // Si j'ai le poids min je peut prendre du poids
        // Si jeu suis entre les deux je peux prendre ou perdre du poids

        float weightDelta = weight - STANDARD_WEIGHT;
        float scaleLevel = weightDelta * MAX_SCALE_LEVELS / MAX_GAIN_WEIGHT;

        if (scaleLevel.IsBetweenEE(1f, 2f))
        {
            currrentWeightLevel = 1;
            //TODO: charger le sprite si necessaire
        }
        else if (scaleLevel.IsBetweenEE(2f, 3f))
        {
            currrentWeightLevel = 2;
            //TODO: charger le sprite si necessaire
        }
        else if (scaleLevel.IsBetweenEE(3f, 4f))
        {
            currrentWeightLevel = 3;
            //TODO: charger le sprite si necessaire
        }
        else if (scaleLevel.IsBetweenEE(4f, 5f))
        {
            currrentWeightLevel = 4;
            //TODO: charger le sprite si necessaire
        }
        else if (scaleLevel.IsBetweenEE(5f, 6f))
        {
            currrentWeightLevel = 5;
            //TODO: charger le sprite si necessaire
        }
        transform.localScale = initialScale + new Vector3(currrentWeightLevel * SCALE_WEIGHT_FACTOR, currrentWeightLevel * SCALE_WEIGHT_FACTOR, 0f);
        Debug.Log("Poids actuel du pigeon : " + weight + " avec scale " + currrentWeightLevel);
    }

    private void ApplyWeightGain(int calories)
    {
        if (this.weight.IsBetweenII(STANDARD_WEIGHT, MAX_WEIGHT - calories))
        {
            Debug.Log("Le pigeon prend un poid de + " + calories);
            this.weight += calories;
            ApplyScaledWeight();
        }
    }

    private void ApplyWeightLose(int calories)
    {
        if (this.weight.IsBetweenII(STANDARD_WEIGHT + calories, MAX_WEIGHT))
        {
            Debug.Log("Le pigeon perds un poid de - " + calories);
            this.weight -= calories;
            ApplyScaledWeight();
        }
    }

    private void ApplyWeightLose()
    {
        ApplyWeightLose(WEIGHT_LOOSE_FACTOR);
    }

    #endregion

    #region Gestion du evenements clavier

    private void Fly()
    {
        y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, y, 0);
    }

    private void Sprint()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
    }

    #endregion
}
