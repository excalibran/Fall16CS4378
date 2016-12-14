using UnityEngine;
using System.Collections;

/*
 This class causes an enemy to rotate to and move towards the player position. Unity's rotation functions do not function well in 2D,
 and we were never able to calculate a proper full rotation around only the z axis.
   */

public class FollowPlayer : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	Transform player;
	Vector3 up;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
  }
	
	void Update () {

		if (player.position.x > transform.position.x) {
			up = new Vector3 (-1, 0,-1);
		} else if (player.position.x < transform.position.x) {
			up = new Vector3 (1, 0,-1);
    }
    
    transform.LookAt (player,up);

		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z );
		transform.position += (player.position - transform.position).normalized * speed * Time.deltaTime;
	}
}
