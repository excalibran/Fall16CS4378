using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {
  
  public bool actionButton;
  public bool leftArrow;
  public bool downArrow;
  public bool rightArrow;
  public bool upArrow;
  
  public bool acceptingInput = true;
  public Vector2 target = Vector2.zero;
  public Vector2 current = Vector2.zero;
  public Vector2 calc = Vector2.zero;

  public float xMin, xMax, yMin, yMax;
  public GameObject shot;
  public GameObject shotSpawn;
	public float fireRate = .5f;
	private float nextFire = 0.0f;


  private Rigidbody2D rgd;

  

  void Awake () {
    rgd = GetComponent<Rigidbody2D>();
  }
	
	// Update is called once per frame
	void Update () {

    rgd.WakeUp();

    actionButton = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return);
    leftArrow = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    downArrow = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
    rightArrow = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D); 
    upArrow = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    

    if (acceptingInput) {

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

			if (actionButton && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
	    }
      rgd.MovePosition(target);
 
	    //rgd.position = new Vector2 (Mathf.Clamp(rgd.position.x, xMin, xMax),Mathf.Clamp(rgd.position.y, yMin, yMax));	
    }
  }

} 