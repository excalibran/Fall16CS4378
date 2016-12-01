using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyProduction : MonoBehaviour {

  public RegionData[] regions;
  public Strategy[] spawnStrats;
  public int evaluateRate;

  // Use this for initialization
  void Start () {
    
    spawnStrats = GetComponents<Strategy>();    
    regions = GetComponentsInChildren<RegionData>();
    Debug.Log("start");
    StartCoroutine(EvaluateStrats());
  }

  //void Update() {
    //Debug.Log(regions[0].playerHere + " " + regions[7].playerHere);
  //}

  IEnumerator EvaluateStrats()
  {
    yield return new WaitForSeconds(evaluateRate);
    Debug.Log("go");

    if (regions[0].playerEnters > 5) {
      Debug.Log("left up");
      spawnStrats[0].valid = true;
    }

    if (regions[7].playerEnters > 5) {
      Debug.Log("right up");
      spawnStrats[1].valid = true;
    }

    foreach (RegionData reg in regions) {
      reg.playerEnters = 0;
    }

    SpawnStrats();
      StartCoroutine(EvaluateStrats());
    }

  void SpawnStrats() {
    foreach (Strategy strat in spawnStrats) {
      if (strat.valid) {
        GameObjectUtil.Instantiate(strat.spawner, strat.pos);
      }
      strat.valid = false;
    }
  }
}
