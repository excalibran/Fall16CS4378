using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyProduction : MonoBehaviour {

  public RegionData[] regions;
  public List<Strategy> spawnStrats;
  //public GameObject spawner;

  // Use this for initialization
  void Start () {
    
    spawnStrats = new List<Strategy>(GetComponents<Strategy>());
    
    regions = GetComponentsInChildren<RegionData>();

    foreach (Strategy strat in spawnStrats) {
      if (strat.valid) {
        GameObjectUtil.Instantiate(strat.spawner, strat.pos);
      }
    }
    
  }
	
	// Update is called once per frame
	//void Update () {
	
	//}
}
