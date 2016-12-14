using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	public GameObject explode;
	public float spawnTime;

	void Start () {

  }

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "EnemyShot" || other.tag == "Mine" || other.tag == "Enemy") {
			GameObjectUtil.Destroy (other.gameObject);
			GameObjectUtil.Instantiate(explode, transform.position);
			LifeTracker.lives--;
			InputState.target = new Vector2(4,-67);
			if (LifeTracker.lives == 0)
				gameObject.SetActive (false);
		}
	}
}