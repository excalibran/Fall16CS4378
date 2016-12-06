using UnityEngine;
using System.Collections;

public class RelativeWaypoints : MonoBehaviour {

  public int bobRange = 5;
  private Vector2 origin;
  private MovingEntity move;

	// Use this for initialization
	void Start () {
    origin = transform.position;
    move = GetComponent<MovingEntity>();
    
    if (move != null) {
      move.waypoint.Add(new Vector2(origin.x - bobRange, origin.y - bobRange));
      move.waypoint.Add(new Vector2(origin.x - bobRange, origin.y + bobRange));
      move.waypoint.Add(new Vector2(origin.x + bobRange, origin.y - bobRange));
      move.waypoint.Add(new Vector2(origin.x + bobRange, origin.y + bobRange));
    }
  }
	
	// Update is called once per frame
	
}
