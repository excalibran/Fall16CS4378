using UnityEngine;
using System.Collections;

public class LeaveAfterPeriod : MonoBehaviour {

  private MovingEntity move = null;
  public Vector2 leavePoint;
  public int delay;
	// Use this for initialization
	void Start () {
    move.GetComponent<MovingEntity>();
    if (move != null) {
      StartCoroutine(addFinalWaypoint());
    }
	}

  IEnumerator addFinalWaypoint() {
    yield return new WaitForSeconds(delay);

    move.waypoint.Add(leavePoint);
  }

  void OnDestroy(){
    move.waypoint.Remove(leavePoint);
  }
}
