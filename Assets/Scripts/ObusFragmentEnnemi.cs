using UnityEngine;
using System.Collections;

public class ObusFragmentEnnemi : Ennemi
{
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        
    }

    public void SetInitialPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetVelocity(Vector3 position)
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.velocity = position;
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollisionWithDeathWall(other);
        HandleCollisionWithPigeon(other);
    }

    #region Non needed

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Reint()
    {
        throw new System.NotImplementedException();
    }

    #endregion
}
