﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
  One of a handful of static helper classes. This one overrides the default methods of instantiate and destruction 
  in order to make automatic object recycling possible. With this, an object only needs the RecycleameObject type be present
  in order to handle making its own object pool.
*/

public class GameObjectUtil{

    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();
  
    public static GameObject Instantiate(GameObject prefab, Vector3 pos) {

        GameObject instance = null;

        var recycledScript = prefab.GetComponent<RecycleGameObject>();

        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        }
        else {
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    public static void Destroy(GameObject gameObject) {

    var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();
    var spawnOnDeath = gameObject.GetComponent<SpawnOnDeath>();

    if (spawnOnDeath) {
      spawnOnDeath.deploy();
    }

    if (recycleGameObject != null) {
            
            recycleGameObject.Shutdown();
            
        }
        else{
            GameObject.Destroy(gameObject);
        }
    }

    private static ObjectPool GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;

        if (pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        else {
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }

        return pool;
    }
}