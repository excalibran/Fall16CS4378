using UnityEngine;
using System.Collections;

public class PlayerVelocity : MonoBehaviour {

  //private Rigidbody2D body2d;
  private InputState inputState;
  public Vector2 current = Vector2.zero;

  private float playerVelocity = 15f;

  // Use this for initialization
  void Start () {

    //body2d = GetComponent<Rigidbody2D>();
    inputState = GetComponent<InputState>();
  }

// Update is called once per frame
void Update () {

    current = new Vector2(transform.position.x,transform.position.y);

    //Vector2.MoveTowards(current, inputState.target, playerVelocity * Time.deltaTime);
    transform.position = Vector2.Lerp(current, inputState.target, playerVelocity * Time.deltaTime);

  }
}
