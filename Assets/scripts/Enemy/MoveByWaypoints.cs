using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 Main movement class. Enemy has a set of waypoints that it moves to by calculating a velocity that is modified by dodging the player.
 Not as autonomous as I would like but more random movement didn't feel very fun. The dodge modifier has to come from a child object
 because Unity cannot have multiple colliders on single object send different kind sof messages
   */

public class MoveByWaypoints : MonoBehaviour
{

  public float speed = 35f;
  public float dodgeSpeed = 1;

  Rigidbody2D rig;
  AvoidPlayerCollision dodgeDetector;
  Vector2 target;
  Vector2 current;
  Vector2 direction;
  Vector2 dodgeModifier;
  public List<Vector2> waypoint;

  private int _curWay = 0;
  public int currentWaypoint
  {
    get
    {
      return _curWay;
    }
    set
    {
      if (_curWay < waypoint.Count - 1 && value != 0)
      {
        _curWay = value;
      }
      else
      {
        _curWay = 0;
      }
    }
  }

  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    dodgeDetector = GetComponentInChildren<AvoidPlayerCollision>();
    dodgeModifier = Vector2.zero;
    current = transform.position;
    currentWaypoint = 0;
    if (waypoint.Count > 0) {
      target = waypoint[currentWaypoint];
    }
   }

  void Update()
  {
    target = waypoint[currentWaypoint];
    if (dodgeDetector != null) {
      dodgeModifier = dodgeDetector.dodgeModifier;
    }
  }

  void FixedUpdate()
  {
    current = transform.position;

    if ((current - target).magnitude < 1)
    {
      currentWaypoint++;
    }
    else
    {
      direction = (target - current).normalized * speed;
    }

    rig.velocity = direction + (dodgeModifier * speed * dodgeSpeed) ;
  } 
}