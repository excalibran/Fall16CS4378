using UnityEngine;
using System.Collections;

public class Strategy : MonoBehaviour {

  public string stratName;
  public Vector2 priority;
  public bool valid;
  public GameObject[] spawners;
  public Vector2[] pos;
  


  // Use this for initialization
  void Start () {
    valid = false;
  }

  public void deploy() {
    for (int i = 0; i < pos.Rank-1; i++) {
      GameObjectUtil.Instantiate(spawners[i], pos[i]);
    }
  }
  //end 
}
