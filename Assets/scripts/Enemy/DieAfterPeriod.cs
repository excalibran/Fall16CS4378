using UnityEngine;
using System.Collections;

/*
  This class destroys the game object it is attached to after a number of seconds
   */

public class DieAfterPeriod : MonoBehaviour {

  public float duration = 1;
  
	// Use this for initialization
	void Start () {
    if (gameObject.activeSelf)
    StartCoroutine(LiveThenDie(duration));
	}

  IEnumerator LiveThenDie(float duration) {
    yield return new WaitForSeconds(duration);

    GameObjectUtil.Destroy(gameObject);
  }
}
