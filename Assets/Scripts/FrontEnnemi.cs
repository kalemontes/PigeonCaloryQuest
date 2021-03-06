using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnnemi : Ennemi
{
    private int L_direction = -1;

    // Use this for initialization
    void Start()
    {

    }

    public override void Move()
    {
        float x = L_direction * Time.deltaTime * speed;
        transform.Translate(x, 0, 0);
    }

    public override void Reint()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(10f, Random.Range(0, 6000f) / 1000, -4f);
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollisionWithDeathWall(other);
        HandleCollisionWithPigeon(other);
    }
}
