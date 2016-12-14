using UnityEngine;
using System.Collections;
using System;

/*
 The regions used for enemy production use Unity collision volumes to detect where the player is moving.
 The regions track wether the player is in this region at the moment, and how many times they've entered
 the region. The cap on the number of times the player entered is a remnant of when the method of obtaining the
 number was more complicated.
*/

public class RegionData : MonoBehaviour
{
  public int id;

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

  void Start()
  {
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
}