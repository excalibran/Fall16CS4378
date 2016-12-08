using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	Transform player;
	Vector3 up;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//up = new Vector3 (0, 0,0);
	}
	
	// Update is called once per frame
	void Update () {

		if (player.position.x > transform.position.x) {
			up = new Vector3 (-1, 0,-1);
		} else if (player.position.x < transform.position.x) {
			up = new Vector3 (1, 0,-1);
		}
		transform.LookAt (player,up);

		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);
		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z );


		transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;

	}
}
