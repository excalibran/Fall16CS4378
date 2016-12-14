using UnityEngine;
using System.Collections;

/*
 This class handles Enemy collisions. Enemy collision volumes were 
 treated as triggers rather than hard collisions in order to keep them from bumping into one another
   */

public class EnemyDeath : MonoBehaviour {

	public int scoreValue = 10;

  void Start() { }


	void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player"){
      GameObjectUtil.Destroy(gameObject);
    }

      if (other.tag == "PlayerShot") {
      GameObjectUtil.Destroy(other.gameObject);
			ScoreTracker.newLifeScore += scoreValue;
			ScoreTracker.superScore += scoreValue;
			ScoreTracker.score += scoreValue;

      GameObjectUtil.Destroy(gameObject);
    }
	}
}
