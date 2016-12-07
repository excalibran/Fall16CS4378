using UnityEngine;
using System.Collections;

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
