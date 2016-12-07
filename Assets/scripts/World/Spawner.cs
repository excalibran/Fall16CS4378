using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

  public GameObject[] prefabs;
  public float delay = 2.0f;
  public bool active = true;
  public int maxSpawns = 3;
    
	// Use this for initialization
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
      //ResetDelay();
      StartCoroutine(EnemyGenerator());
    }
    else {
      GameObjectUtil.Destroy(gameObject);
    }
  }

  void ResetDelay() {
      //delay = Random.Range(delayRange.x, delayRange.y);
  }
  
}
