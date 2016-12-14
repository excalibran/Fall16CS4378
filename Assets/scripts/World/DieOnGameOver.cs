using UnityEngine;
using System.Collections;

    /*
    When game ends, remaining objects destroy themselves so the game can begin anew without reloading the entire scene
   
   */

public class DieOnGameOver : MonoBehaviour {
   

  void Update()
  {
    if (LifeTracker.lives <= 0)
    {
      GameObjectUtil.Destroy(gameObject);
    }
  }
}
