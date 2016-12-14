using UnityEngine;
using System.Collections;

/*
  The attached gameobject will, after a delay, recieve a new waypoint that instructs them to head offscreen and die. Intended to control
  the overall number of enemies onscreen.
   */

public class LeaveAfterPeriod : MonoBehaviour {

  private MoveByWaypoints move = null;
  public Vector2 leavePoint;
  public int delay;
	// Use this for initialization
	void Start () {
    move = GetComponent<MoveByWaypoints>();
    if (move != null && gameObject.activeSelf) {
      StartCoroutine(addFinalWaypoint());
    }
	}

  IEnumerator addFinalWaypoint() {
    yield return new WaitForSeconds(delay);

    move.waypoint.Add(leavePoint);
  }

  void OnDisable() {
    move.waypoint.Remove(leavePoint);
  }
}
