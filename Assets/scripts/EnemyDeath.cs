using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public int scoreValue;


	void Start(){

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Shot") {
			Destroy (other.gameObject);
			gameObject.SetActive (false);
			ScoreTracker.score += 10;
		}
	}
}
