using UnityEngine;
using System.Collections;

public class PlayerVelocity : MonoBehaviour{

  private InputState inputState;
  private Vector2 Bounds;
  public bool ignoreBounds = false;
  
  public Vector2 current = Vector2.zero;
  public Vector2 target = Vector2.zero;

  private float playerVelocity = 15f;

  // Use this for initialization
  void Start () {

    inputState = GetComponent<InputState>();

  }

// Update is called once per frame
void Update () {
    
    current = new Vector2(transform.position.x,transform.position.y);
    Debug.DrawLine(current, inputState.target, Color.red, .1f, false);
    transform.position = Vector2.Lerp(current, inputState.target, playerVelocity * Time.deltaTime);

  }
}
