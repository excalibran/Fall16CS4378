using UnityEngine;
using System.Collections;

public class DieAfterPeriod : MonoBehaviour {

  public float duration = 1;
  
	// Use this for initialization
	void Start () {
    StartCoroutine(LiveThenDie(duration));
	}

  IEnumerator LiveThenDie(float duration) {
    yield return new WaitForSeconds(duration);

    GameObjectUtil.Destroy(gameObject);
  }
}
