using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleInputMouse : MonoBehaviour
{
    public Transform point;
    private Rigidbody2D rigidBody2D;
    private Vector3 cursorPos;
    private Vector3 direction;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        point.position = cursorPos;
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (cursorPos - transform.position).normalized;

        PushBall(direction);
    }

    void PushBall(Vector3 dir)
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody2D.velocity = new Vector2(dir.x * 15, dir.y * 15);
        }
    }
}
