﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject threatData;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);
    

	// Use this for initialization
	void Start () {

    Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
    GameObjectUtil.Instantiate(threatData, center);

    delay = Random.Range(delayRange.x, delayRange.y);
    StartCoroutine(EnemyGenerator());
	}
  
  
  IEnumerator EnemyGenerator() {

   //Debug.Log("executing");

    yield return new WaitForSeconds(delay);

      if (active){
        var setTransform = transform;

        GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], setTransform.position);
        ResetDelay();
      }
        
      StartCoroutine(EnemyGenerator());
  }

  void ResetDelay() {
      delay = Random.Range(delayRange.x, delayRange.y);
  }
  
}
