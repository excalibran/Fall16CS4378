using UnityEngine;
using System.Collections;

 /*
  Uses GameObjectUtil to spawn another object in the event the object this is attached to is destroyed.
   */

public class SpawnOnDeath : MonoBehaviour {

  public GameObject[] spawnWhatOnDie;
  public bool spawnOnSelfOnDie = false;
  public Vector2 spawnWhereOnDie;

  // Use this for initialization
  void Start () {

  }

  public void deploy()
  {
    if (spawnOnSelfOnDie){
      spawnWhereOnDie = transform.position;
    }

    foreach (GameObject shot in spawnWhatOnDie) {
      GameObjectUtil.Instantiate(shot, spawnWhereOnDie);
    }
  }
}
