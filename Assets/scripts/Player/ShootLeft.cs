using UnityEngine;
using System.Collections;

public class ShootLeft : MonoBehaviour {

	private Rigidbody2D rgd;
	public float speed;


	// Use this for initialization

	void Awake(){
		rgd = GetComponent<Rigidbody2D>();
	}

	void Start () {
		rgd.velocity = new Vector2(-1,1) * speed;
	}

	// Update is called once per frame
	void Update () {
		if (rgd.position.y > 90){
			GameObjectUtil.Destroy (gameObject);
		}
	}

}