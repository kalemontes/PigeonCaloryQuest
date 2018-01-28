using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PigeonMouvement : MonoBehaviour
{
    private const int STANDARD_WEIGHT = 350;    //360 grammes est le poid standard pour un pigeon biset
    private const int MAX_WEIGHT = 500;
    private const int MAX_GAIN_WEIGHT = MAX_WEIGHT - STANDARD_WEIGHT;
    private const int MAX_SCALE_LEVELS = 5;
    private const float SCALE_WEIGHT_FACTOR = 0.5f;
    private const int WEIGHT_LOOSE_FACTOR = 5;  // nombre de grammes perdus par le pigeon à chaque effort

    private const int MIN_DRAG = 1;
    private const int MAX_DRAG = 10;

    private Vector3 initialScale;
    private Rigidbody rigidBody;

    public float speed;
    public float weight;
    int currrentWeightLevel;

    // Use this for initialization
    void Start()
    {
        //TODO: rotater = GameObject.Find("Cube"); comprendre ce que ça fait ??
        rigidBody = GetComponent<Rigidbody>();
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
        bool didCollideWithEnnemi = HandleCollisionWithEnnemi(other);
        if (didCollideWithEnnemi)
        {
            //TODO: quelque chose ici ?
        }

		if (other.tag == "DeathWall" || other.tag == "Ground") {
			SceneManager.LoadScene("GameOver");
		}
    }

    private bool HandleCollisionWithEnnemi(Collider other)
    {
        bool didHandle = false;
        Ennemi ennemi = other.GetComponent<Ennemi>();
        if (ennemi)
        {
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

    private void ApplyWeightDrag()
    {
        float conversionRatio = (MAX_WEIGHT - STANDARD_WEIGHT) / (MAX_DRAG - MIN_DRAG);
        rigidBody.drag = MAX_DRAG - ((weight - STANDARD_WEIGHT) / conversionRatio);
    }

    private void ApplyWeightGain(int calories)
    {
        if (this.weight.IsBetweenII(STANDARD_WEIGHT, MAX_WEIGHT - calories))
        {
            Debug.Log("Le pigeon prend un poid de + " + calories);
            this.weight += calories;
            ApplyScaledWeight();
            ApplyWeightDrag();
        }
    }


	public float GetSpeed(){
		return speed;
	}

    private void ApplyWeightLose(int calories)
    {
        if (this.weight.IsBetweenII(STANDARD_WEIGHT + calories, MAX_WEIGHT))
        {
            Debug.Log("Le pigeon perds un poid de - " + calories);
            this.weight -= calories;
            ApplyScaledWeight();
            ApplyWeightDrag();
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
        float y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0, y, 0);
    }

    private void Sprint()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
    }

    #endregion

}
