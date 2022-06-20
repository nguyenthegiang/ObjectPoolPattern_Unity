using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;

    [SerializeField]
    Rigidbody2D rb;

    private void FixedUpdate()
    {
        //move bullet
        rb.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //destroy bullet when hits the wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //Destroy(gameObject);

            //Disable GameObject
            //gameObject.SetActive(false);
            ObjectPool.instance.ReturnPooledObject(gameObject);
        }
    }
}
