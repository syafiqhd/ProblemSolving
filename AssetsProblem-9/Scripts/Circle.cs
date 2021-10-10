using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private float rbSpeed;

    public float xInitialForce;
    public float yInitialForce;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        Invoke("PushBall", 0);
        StartCoroutine(PushTime());
    }

    void Update()
    {
        rbSpeed = rigidBody2D.velocity.magnitude;
        Debug.Log(rbSpeed);

        if (rbSpeed <= 7) 
        {
            PushBall();
        }

        if (rbSpeed >= 22) 
        {
            rigidBody2D.velocity = rigidBody2D.velocity.normalized * 10;
        }
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

    IEnumerator PushTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);
            PushBall();
        }
    }
}
