using UnityEngine;
using System.Collections;

public class MovingEntity : MonoBehaviour {

  public InputState inputState;
  public bool forcedMove = false;
  private Vector2 forcedMoveTarget;
  private Vector2 bounds;
  public bool ignoreBounds = false;

  public Vector2 target = Vector2.zero;

  private float playerVelocity = 15f;

  // Use this for initialization

  void Start()
  {
    inputState = GetComponent<InputState>();
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 current = new Vector2(transform.position.x, transform.position.y);

    if (!forcedMove)
    {
      target = inputState.target;
      
    }
    else {

      if (Input.GetKey(KeyCode.J)) {
        forcedMoveTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      }
      
      target = forcedMoveTarget;
    }

    transform.position = Vector2.Lerp(current, target, playerVelocity * Time.deltaTime);

    Debug.DrawLine(current, target, Color.red, .1f, false);
    
  }

}
