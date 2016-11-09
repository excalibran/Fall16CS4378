using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {
  
  public bool actionButton;
  public bool leftArrow;
  public bool downArrow;
  public bool rightArrow;
  public bool upArrow;
  
  public bool acceptingInput = true;
  public bool mouseXokay;
  public bool mouseYokay;
  public Vector2 mousePoint = Vector2.zero;
  public Vector2 target = Vector2.zero;
  public Vector2 current = Vector2.zero;
  public Vector2 calc = Vector2.zero;

  

  void Awake () {
      
	}
	
	// Update is called once per frame
	void Update () {
    
    
    actionButton = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return);
    leftArrow = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    downArrow = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    rightArrow = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D); 
    upArrow = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    

    if (acceptingInput) {

      /*
      mousePoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);
      mousePoint = Camera.main.ScreenToViewportPoint(Input.mousePosition);

      mouseXokay = (mousePoint.x > 0 && mousePoint.x < 1) ? true : false;
      mouseYokay = (mousePoint.y > 0 && mousePoint.y < 1) ? true : false;

      if ( mouseXokay && mouseYokay) {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
      }
      */

      calc = Vector2.zero;

      if (leftArrow){
        calc += Vector2.left * 150f * Time.deltaTime;
      }

      if (rightArrow){
        calc += Vector2.right * 150f * Time.deltaTime;
      }

      if (downArrow){
        calc += Vector2.down * 150f * Time.deltaTime;
      }

      if (upArrow){
        calc += Vector2.up * 150f * Time.deltaTime;
      }

      target += calc;
    }
  }

}