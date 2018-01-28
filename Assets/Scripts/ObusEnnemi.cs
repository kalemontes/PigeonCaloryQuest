using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObusEnnemi : Ennemi {

    public GameObject prefabObusFrag;

    private const int MAX_REACH_OBUS = 5;
    private const int FRAGMENTS_NUM = 4;
    private GameObject[] fragments;

    // Use this for initialization
    void Start () {
        CreateFragments();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Move()
    {
        float y = Time.deltaTime * speed;
        if(transform.position.y < MAX_REACH_OBUS)
        {
            transform.Translate(0, y, 0);
        } else
        {
            gameObject.SetActive(false);
            ExploseIntoFragments();
        }
    }

    public override void Reint()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(Random.Range(-14f, 14f), -2.82f, -4f);
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollisionWithDeathWall(other);
        HandleCollisionWithPigeon(other);
    }

    protected new bool HandleCollisionWithDeathWall(Collider other)
    {
        bool didHandleColission = false;
        if (other.tag == "DeathWall")
        {
            gameObject.SetActive(false);
            Debug.Log("Collission avec le DeathWall, l'ennemi sera detruit");
            didHandleColission = true;
        }
        return didHandleColission;
    }

    private void CreateFragments()
    {
        fragments = new GameObject[FRAGMENTS_NUM];
        for (int i = 0; i < FRAGMENTS_NUM; i++)
        {
            fragments[i] = Instantiate(prefabObusFrag, new Vector3(0, 0, 0), Quaternion.identity);
            fragments[i].SetActive(false);
        }
    }

    private void ReintFragments()
    {
        for (int i = 0; i < FRAGMENTS_NUM; i++)
        {
            fragments[i].GetComponent<ObusFragmentEnnemi>().Reint();
        }
    }

    protected void ExploseIntoFragments()
    {
        Vector3 vel;
        for (int i = 0; i < FRAGMENTS_NUM; i++)
        {
            switch(i)
            {
                case 1:
                    vel = new Vector3(-1,1,0);
                    break;
                case 2:
                    vel = new Vector3(1,1,0);
                    break;
                case 3:
                    vel = new Vector3(1,-1,0);
                    break;
                default:
                    vel = new Vector3(-1,-1,0);
                    break;
            }
            fragments[i].GetComponent<ObusFragmentEnnemi>().SetInitialPosition(transform.position);
            fragments[i].SetActive(true);
            fragments[i].GetComponent<ObusFragmentEnnemi>().SetVelocity(vel);
            
        }
    }
}
