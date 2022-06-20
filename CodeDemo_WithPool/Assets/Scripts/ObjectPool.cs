using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //use Singleton for other classes to access this class without a reference to it
    public static ObjectPool instance;

    //for Object Pool
    private List<GameObject> poolObjects = new List<GameObject>();
    private int amountToPool = 20;

    //for making the pool
    [SerializeField]
    private GameObject bulletPrefab;

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Make the Pool
        for (int i = 0; i < amountToPool; i++)
        {
            //make objects
            GameObject obj = Instantiate(bulletPrefab);
            //disable it
            obj.SetActive(false);
            //add to pool
            poolObjects.Add(obj);
        }
    }

    //get an Object from the Pool
    public GameObject GetPooledObject()
    {
        //Linear Search
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        return null;
    }
}
