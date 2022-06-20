using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    //for moving
    private float vertical;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    float speed;

    //for shooting
    [SerializeField]
    private GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        //get input
        vertical = Input.GetAxisRaw("Vertical");

        //shoot
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        //create bullet
        Vector3 bulletPosition = new Vector3(transform.position.x + 1, transform.position.y, 0);
        Instantiate(bulletPrefab, bulletPosition, Quaternion.Euler(0, 0, -90));
    }

    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector2(0, vertical * speed);
    }
}
