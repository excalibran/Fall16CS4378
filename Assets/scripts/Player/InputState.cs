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

			if (chargerCounter > 45) {
				// fire once fully charged.
				nextFire = Time.time + fireRate;
				Instantiate (shotLeft, shotSpawnLeft.transform.position, shotSpawnLeft.transform.rotation);
				Instantiate (shotRight, shotSpawn.transform.position, shotSpawnRight.transform.rotation);
				Instantiate (shot, shotSpawnRight.transform.position, shotSpawn.transform.rotation);
				shootingSounds.clip = chargeFireSound;
				shootingSounds.Play ();					
				charging = false;
				chargerCounter = 0;
			}

			else if (Input.GetButtonDown("Fire1")){
				// first time fire button pressed 
				charging = true;
				chargeAudioPlayed = false;
			}

			else if(Input.GetButton("Fire1") && charging){
				// start charge counter
				chargerCounter++;
				if (chargerCounter > 5 && !chargeAudioPlayed) {
					// after fire held start charging wepon
					shootingSounds.clip = chargeUpSound;
					shootingSounds.Play ();
					chargeAudioPlayed = true;
				}

			}

			else if(Input.GetButtonUp("Fire1") && Time.time > nextFire){
				// non charged shot
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
				shootingSounds.clip = fireSound;
				shootingSounds.Play ();						
				charging = false;
				chargerCounter = 0;
			}


			// keeping player in bounds
			target += calc;
			if (target.y > 69)
				target.y = 69;
			if (target.y < -69)
				target.y = -69;
			if (target.x > 98)
				target.x = 98;
			if (target.x < -98)
				target.x = - 98;

			rgd.MovePosition (target);
		}
	}

} 