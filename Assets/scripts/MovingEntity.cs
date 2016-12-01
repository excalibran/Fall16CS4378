using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingEntity : MonoBehaviour
{

  Rigidbody2D rig;
  DodgeDetection dodgeDetector;
  RaycastHit2D seePlayerRight;
  RaycastHit2D seePlayerLeftRight;

  List<RaycastHit2D> feel;

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
        Debug.Log("up " + _curWay);
      }
      else
      {
        _curWay = 0;
        Debug.Log(_curWay);
      }
    }
  }

  public float speed = 35f;

  // Use this for initialization

  void Start()
  {
    rig = GetComponent<Rigidbody2D>();
    dodgeDetector = GetComponentInChildren<DodgeDetection>();
    dodgeModifier = Vector2.zero;
    current = transform.position;

    currentWaypoint = 0;
    target = waypoint[currentWaypoint];
  }

  // Update is called once per frame
  void Update()
  {
    target = waypoint[currentWaypoint];
    dodgeModifier = dodgeDetector.dodgeModifier;
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

    rig.velocity = direction + (dodgeModifier * speed * 5) ;
  } 
}