using UnityEngine;
using System.Collections;

public class InputState : MonoBehaviour {

	public bool leftArrow;
	public bool downArrow;
	public bool rightArrow;
	public bool upArrow;

	public static Vector2 target = Vector2.zero;
	public Vector2 current = Vector2.zero;
	public Vector2 calc = Vector2.zero;

	public float xMin, xMax, yMin, yMax;
	public GameObject shot, shotLeft, shotRight;
	public GameObject shotSpawn, shotSpawnLeft, shotSpawnRight;
	public AudioSource shootingSounds;
	public AudioClip fireSound;
	public AudioClip chargeUpSound;
	public AudioClip chargeFireSound;
	public float fireRate = .5f;

	private float nextFire = 0.0f;
	private int chargerCounter = 0;
	private bool charging = false;
	private bool chargeAudioPlayed = false;

	private Rigidbody2D rgd;
  
	void Awake () {
    //make sure to get rigidbody before anything else happens
		rgd = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

    // forces the rigidbody to perform at leas one calculation, even if nothing else happens this update
    // this ensures that collision with the EnemyProduction regions always happens
		rgd.WakeUp();

    /*
     Get keyboard keys and calculate target vector direction. Actual motion is applied down on line 88.
     The MovingEntity calculation from the text was not used as manipulating velocity/acceleration prevented the player 
     from stopping motion easily.
    */

		leftArrow = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
		downArrow = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
		rightArrow = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D); 
		upArrow = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

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

    // fire weapon if player is pressing/holding fire button
    fireWeapon();

		// keeping player in bounds
		
		if (target.y > 69)
			target.y = 69;
		if (target.y < -69)
			target.y = -69;
		if (target.x > 98)
			target.x = 98;
		if (target.x < -98)
			target.x = - 98;

    //move player towards target. Function name implies that only position changes, documentation states that appropriate physics
    //calculations are made for the points in between.
    rgd.MovePosition (target);
	}

  void fireWeapon() {
    if (chargerCounter > 45)
    {
      // fire once fully charged.
      nextFire = Time.time + fireRate;
      Instantiate(shotLeft, shotSpawnLeft.transform.position, shotSpawnLeft.transform.rotation);
      Instantiate(shotRight, shotSpawn.transform.position, shotSpawnRight.transform.rotation);
      Instantiate(shot, shotSpawnRight.transform.position, shotSpawn.transform.rotation);
      shootingSounds.clip = chargeFireSound;
      shootingSounds.Play();
      charging = false;
      chargerCounter = 0;
    }

    else if (Input.GetButtonDown("Fire1"))
    {
      // first time fire button pressed 
      charging = true;
      chargeAudioPlayed = false;
    }

    else if (Input.GetButton("Fire1") && charging)
    {
      // start charge counter
      chargerCounter++;
      if (chargerCounter > 5 && !chargeAudioPlayed)
      {
        // after fire held start charging wepon
        shootingSounds.clip = chargeUpSound;
        shootingSounds.Play();
        chargeAudioPlayed = true;
      }
    }

    else if (Input.GetButtonUp("Fire1") && Time.time > nextFire)
    {
      // non charged shot
      nextFire = Time.time + fireRate;
      Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
      shootingSounds.clip = fireSound;
      shootingSounds.Play();
      charging = false;
      chargerCounter = 0;
    }
  }
} 