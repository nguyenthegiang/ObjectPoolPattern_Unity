using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Better in performance thanks to improving Algorithm 
//Source: Dr.T
/*
 Difference with the old way:
     - Old way: when get an object from the pool -> do linear search -> O(n) operation 
                => will take longer as the list gets larger
     - New way: all operations are O(1)
 => Better
 */
public class ObjectPool : MonoBehaviour
{
    //use Singleton for other classes to access this class without a reference to it
    public static ObjectPool instance;

    //for Object Pool
    private List<GameObject> poolObjects = new List<GameObject>();
    //private int amountToPool = 20;

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

        //create and fill pool
        poolObjects = new List<GameObject>(2);  //2 for demonstration
        //use "Capacity" because Pool is empty, but we need to fill it
        for (int i = 0; i < poolObjects.Capacity; i++)
        {
            poolObjects.Add(GetNewPooledObject());
        }
        //start small => avoid O(n) operation
    }

    //get an Object from the Pool
    public GameObject GetPooledObject()
    {
        //check for available object in pool
        if (poolObjects.Count > 0)
        {
            //get object at the end of the list because RemoveAt() would be O(1)
            GameObject obj = poolObjects[poolObjects.Count - 1];
            poolObjects.RemoveAt(poolObjects.Count - 1);
            return obj;
        } else
        {
            Debug.Log("Growing pool ...");

            //pool empty => expand pool and return new object
            /*
             increase capacity is only O(n) if Count > 0;
             but we only do this when Count == 0
             => this is O(1)
             */
            poolObjects.Capacity++;
            return GetNewPooledObject();
            //=> make new object & also put it in the pool -> avoid increase Capacity, which would be O(n)
        }
    }

    //return object to the pool (when it's no longer needed)
    public void ReturnPooledObject(GameObject pooledObject)
    {
        //set it to inactive
        pooledObject.SetActive(false);
        //add the object back to the pool
        /*it will be added to the back of the list;
          it will always be O(1) because we expand the capacity as we needed to 
          => the capacity of the list is always the same as the total number of Pooled Objects in the game*/
        poolObjects.Add(pooledObject);
    }

    //get a new Pooled Object
    private GameObject GetNewPooledObject()
    {
        //make objects
        GameObject obj = Instantiate(bulletPrefab);
        //disable it
        obj.SetActive(false);

        return obj;
    }
}
