using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {
  /*
  public bool actionButton;
  public bool leftArrow;
  public bool downArrow;
  public bool rightArrow;
  public bool upArrow;
  */
  public bool acceptingInput = true;
  public bool mouseXokay;
  public bool mouseYokay;
  public Vector2 mousePoint = Vector2.zero;
  public Vector2 target = Vector2.zero;

  public float absVelX = 0f;
  public float absVelY = 0f;
  public bool standing;
  public float standingThreshold = 1;

  //private Rigidbody2D body2d;

  void Awake () {
      //body2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
    
    /*
    actionButton = Input.GetKeyDown(KeyCode.Space);
    leftArrow = Input.GetKeyDown(KeyCode.LeftArrow);
    downArrow = Input.GetKeyDown(KeyCode.DownArrow);
    rightArrow = Input.GetKeyDown(KeyCode.RightArrow);
    upArrow = Input.GetKeyDown(KeyCode.UpArrow);
    */
    if (acceptingInput) {

      mousePoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);

      mouseXokay = (mousePoint.x > 0 && mousePoint.x < 1) ? true : false;
      mouseYokay = (mousePoint.y > 0 && mousePoint.y < 1) ? true : false;

      if ( mouseXokay && mouseYokay) {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
      }
      
    }
  }

}
