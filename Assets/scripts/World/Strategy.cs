using UnityEngine;
using System.Collections;

/*
Enemy Production checks where the player is and where they are moving, and marks strategies as valid. Strategies then create spawners. 
   */

public class Strategy : MonoBehaviour {

  public string stratName;
  public Vector2 priority;
  public bool valid;
  public GameObject[] spawners;
  public Vector2[] pos;

  void Start () {
    
  }

  public void deploy() {
    for (int i = 0; i < pos.Rank; i++) {
      GameObjectUtil.Instantiate(spawners[i], pos[i]);
    }
  } 
}
