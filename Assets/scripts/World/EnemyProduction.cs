using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyProduction : MonoBehaviour {

  public RegionData[] regions;
  public Strategy[] spawnStrats;
  public int evaluateRate;
  public Vector2 priority;
  public int highest;

  // Use this for initialization
  void Start () {
    
    spawnStrats = GetComponents<Strategy>();    
    regions = GetComponentsInChildren<RegionData>();
    StartCoroutine(EvaluateStrats());
  }

  IEnumerator EvaluateStrats()
  {
    yield return new WaitForSeconds(evaluateRate);

    for (int i = 0; i < regions.Rank; i++) {
      if (regions[i].playerHere) priority.x = i;
      if (regions[i].playerEnters > highest) {
        priority.y = i;
        highest = regions[i].playerEnters;
      }
    }

    for (int i = 0; i < spawnStrats.Rank; i++) {
      if (priority.x == spawnStrats[i].priority.x || priority.y == spawnStrats[i].priority.y) {
        spawnStrats[i].valid = true;
      }
    }

    foreach (RegionData reg in regions) {
      reg.playerEnters = 0;
      reg.playerHere = false;
    }

	highest = 0;
    SpawnStrats();
    StartCoroutine(EvaluateStrats());
  }

  void SpawnStrats() {
    foreach (Strategy strat in spawnStrats) {
      if (strat.valid) {
				//Debug.Log ("ready");	
        strat.deploy();
				strat.valid = false;
      }
      
    }
  }
}
