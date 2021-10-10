using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    public float xInitialForce;
    public float yInitialForce;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        Invoke("PushBall", 0);
    }

    void Update()
    {
        
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
}
