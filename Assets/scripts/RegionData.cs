using UnityEngine;
using System.Collections;

public class RegionData : MonoBehaviour
{

  public GameObject[] regions;
  public GameObject region;
  public int worldWidth = 3;
  public int worldHeight = 3;

  // Use this for initialization
  void Start()
  {
    regions = new GameObject[worldWidth * worldHeight];

    //regions[0] = ;
  }

  // Update is called once per frame
  void Update()
  {

  }
}