using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    Rigidbody2D rb;

    //using Action to handle logic for destroying the bullet in the Spaceship Script
    private Action<Bullet> _killAction;

    private void FixedUpdate()
    {
        //move bullet
        rb.velocity = Vector2.right * speed;
    }

    //pass method in
    public void Init(Action<Bullet> killAction)
    {
        _killAction = killAction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy bullet when hits the wall
        if (collision.transform.CompareTag("Wall"))
        {
            _killAction(this);
        }
    }
}
