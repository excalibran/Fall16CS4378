using UnityEngine;
using System.Collections;

public class Strategy : MonoBehaviour {

  public string stratName;
  public bool valid;
  public GameObject[] prefabs;
  public GameObject spawner;
  public Vector2 pos = Vector2.zero;

  // Use this for initialization
  void Start () {
    pos = spawner.transform.position;
	}
	//end
}
