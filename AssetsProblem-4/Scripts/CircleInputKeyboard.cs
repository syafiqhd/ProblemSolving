using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInputKeyboard : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        Vector2 velocity = rigidBody2D.velocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = speed;
        }
        else
        {
            velocity.y = 0;
            velocity.x = 0;
        }

        rigidBody2D.velocity = velocity;
    }
}
