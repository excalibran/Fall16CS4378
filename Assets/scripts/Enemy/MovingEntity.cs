using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingEntity : MonoBehaviour
{

  public float speed = 35f;
  public float dodgeSpeed = 1;

  Rigidbody2D rig;
  DodgeDetection dodgeDetector;
  public Vector2 target;
  public Vector2 current;
  public Vector2 direction;
  public Vector2 dodgeModifier;
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
        //Debug.Log("up " + _curWay);
      }
      else
      {
        _curWay = 0;
        //Debug.Log(_curWay);
      }
    }
  }

  // Use this for initialization

  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    dodgeDetector = GetComponentInChildren<DodgeDetection>();
    dodgeModifier = Vector2.zero;
    current = transform.position;
    currentWaypoint = 0;
    if (waypoint.Count > 0) {
      target = waypoint[currentWaypoint];
    }
   }

  // Update is called once per frame
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