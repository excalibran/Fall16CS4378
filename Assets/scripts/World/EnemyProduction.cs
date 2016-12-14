using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 The Enemy Production object resides in the scene and is aware of a 9x9 grid of collision volumes(regions). 
 These collide with the player and every few seconds the game goes over the collision results and marks a 
 number of Strategies(spawnstrats) as applicable. These are then spawned, the data is cleared and the process begins again.
 I would have liked to have it test more data over time, but the system already doesn't work very well to begin with and doesn't produce
 a very fun game.
*/

public class EnemyProduction : MonoBehaviour {

  public RegionData[] regions;
  public Strategy[] spawnStrats;
  public int evaluateRate;
  public Vector2 priority;
  public int highest;

  void Start () {
    
    spawnStrats = GetComponents<Strategy>();    
    regions = GetComponentsInChildren<RegionData>();
    priority = new Vector2(4,4);
    highest = 0;
    StartCoroutine(EvaluateStrats());
  }

  IEnumerator EvaluateStrats()
  {
    yield return new WaitForSeconds(evaluateRate);

    for (int i = 0; i < 8; i++) {
      if (regions[i].playerHere) { priority.x = i;}
      if (regions[i].playerEnters > highest) {
        priority.y = i;
        highest = regions[i].playerEnters;
      }
    }

		Debug.Log (priority.x + " " + priority.y);

    for (int i = 0; i < spawnStrats.Rank; i++) {
      if (priority.x == spawnStrats[i].priority.x || priority.y == spawnStrats[i].priority.y) {
        spawnStrats[i].valid = true;
      }
    }

    foreach (RegionData reg in regions) {
      reg.resetValues();
    }

	  highest = 0;
    SpawnStrats();

    StartCoroutine(EvaluateStrats());
  }

  void SpawnStrats() {
    foreach (Strategy strat in spawnStrats) {
      if (strat.valid) {
        strat.deploy();
		strat.valid = false;
      }
      
    }
  }
}
