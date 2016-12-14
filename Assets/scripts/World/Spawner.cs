using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 Instantiates a number of gameobjects from its array, and then destroys itself. The intention is that ENemyProduction chooses a set
 of strategies, which create a number of spawners which then produce enemy waves
   */

public class Spawner : MonoBehaviour {

  public GameObject[] prefabs;
  public float delay = 2.0f;
  public bool active = true;
  public int maxSpawns = 3;
    
	void Start () {
    delay = 6;
    StartCoroutine(EnemyGenerator());
	}
  
  IEnumerator EnemyGenerator() {

    yield return new WaitForSeconds(delay);

    if (active && maxSpawns > 0)
    {
      var setTransform = transform;
      GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], setTransform.position);
      if(gameObject.activeSelf)
        StartCoroutine(EnemyGenerator());
    }
    else {
      GameObjectUtil.Destroy(gameObject);
    }
  }
}
