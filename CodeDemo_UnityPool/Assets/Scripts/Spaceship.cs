using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Library
using UnityEngine.Pool;

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
    //private GameObject bulletPrefab;
    private Bullet bulletPrefab;

    //Pool from Unity
    private ObjectPool<Bullet> pool;

    private void Start()
    {
        //create the Pool
        pool = new ObjectPool<Bullet>(
            () =>
            {
                /*create function: 
                 * called when there're no objects available in Pool
                 * -> need to create one
                 */
                return Instantiate(bulletPrefab);
            },
            bullet =>
            {
                /*onGet function: 
                 * when we ask for 1 object, and there is 1 available in Pool
                 * -> returns an object
                 */
                //active it
                bullet.gameObject.SetActive(true);
            },
            bullet =>
            {
                /*onRelease function:
                 * when we're done with the object -> give it back to the Pool
                 */
                //deactive it
                bullet.gameObject.SetActive(false);
            },
            bullet =>
            {
                /*destroy action:
                 * this pool will always spawn objects when we ask for them, even
                 * if it's above the Maximum. Once we spawn it, and it goes to to
                 * return to the pool, if the pool is already filled
                 * => it will destroy the object instead
                 */
                Destroy(bullet.gameObject);
            },
            //not important 
            false,
            //default capacity
            10,
            //max size
            20
        );
    }

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
        //create bullet with Pool
        Bullet bullet = pool.Get();
        bullet.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
        bullet.transform.rotation = Quaternion.Euler(0, 0, -90);
        bullet.Init(killAction);
    }

    //method to destroy bullet, to pass in the Bullet Script
    private void killAction(Bullet bullet)
    {
        //Destroy(bullet.gameObject);

        //using Pool:
        pool.Release(bullet);
    }

    private void FixedUpdate()
    {
        //move
        rb.velocity = new Vector2(0, vertical * speed);
    }
}
