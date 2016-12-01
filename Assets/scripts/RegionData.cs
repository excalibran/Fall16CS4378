using UnityEngine;
using System.Collections;
using System;

public class RegionData : MonoBehaviour
{
  public int id;
  public float delayOnDecrease = 1f;

  private int _playerHere;
  public int playerHere 
  {
    get { return _playerHere; }
    set {
      if (_playerHere >= 0 && _playerHere < 1000) {
        _playerHere += value;
      }
    }
  }

  private int _playerEnters;
  public int playerEnters
  {
    get { return _playerEnters; }
    set
    {
      if (_playerEnters >= 0 && _playerEnters < 1000)
      {
        _playerEnters += value;
      }
    }
  }

  // Use this for initialization
  void Start()
  {
    //StartCoroutine(decreaseValues());
  }
  /*
  void OnTriggerStay2D(Collider2D other){
    if (other.gameObject.tag == "Player") {
      playerHere += 2;
      //StartCoroutine(increaseValue());
      Debug.Log(playerHere);
    }
  }
  */
  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player")
    {
      playerEnters += 1;
      //Debug.Log(playerEnters);
    }
  }

  IEnumerator increaseValue() {
    yield return new WaitForSeconds(delayOnDecrease);

    playerHere += 1;
  }

  IEnumerator decreaseValues() {
    yield return new WaitForSeconds(delayOnDecrease);

      playerHere -= 1;
      playerEnters -= 1;
    
    StartCoroutine(decreaseValues());
  }

  //end
}