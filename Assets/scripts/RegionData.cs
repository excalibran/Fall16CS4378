using UnityEngine;
using System.Collections;
using System;

public class RegionData : MonoBehaviour
{
  public int me;
  public float delayOnDecrease = 1f;
  int time;
  private int _playerHere;
  public int playerHere 
  {
    get { return _playerHere; }
    set {
      if (_playerHere > 0 && _playerHere < 1000) {
        _playerHere += value;
      }
    }
  }


  // Use this for initialization
  void Start()
  {

    StartCoroutine(decreaseValues());
    //time = DateTime.Now.Millisecond;
    //Debug.Log("I'm object " + me + " at " + time);

  }

  /*
  void Update() {
    Debug.Log(playerHere);
  }
  */

  void OnTriggerStay2D(Collider2D other){
    if (other.CompareTag("Player")) {
      playerHere += 1;
    }
  }

  IEnumerator decreaseValues() {
    yield return new WaitForSeconds(delayOnDecrease);

    if(playerHere > 0) playerHere -= 2;

    StartCoroutine(decreaseValues());
  }

  //end
}