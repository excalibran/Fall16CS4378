using UnityEngine;
using System.Collections;
using System;

public class RegionData : MonoBehaviour
{
  public int id;
  public float delayOnDecrease = 1f;

  public bool playerHere;

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
  
  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player")
    {
      playerEnters += 1;
    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      playerHere = false;
    }
  }

  void OnTriggerStay2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      playerHere = true;
    }
  }

  public void resetValues() {
    playerHere = false;
    playerEnters = 0;
  }
/*
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
  */
  //end
}