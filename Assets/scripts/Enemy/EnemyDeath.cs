using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	public int scoreValue = 10;

  void Start() { }

	void OnTriggerEnter2D(Collider2D other){
    if (other.tag == "Player"){
//      Debug.Log("clang");
      //ScoreTracker.score += scoreValue;
      GameObjectUtil.Destroy(gameObject);
    }

      if (other.tag == "PlayerShot") {
      GameObjectUtil.Destroy(other.gameObject);
			Debug.Log ("ememy dead");
			ScoreTracker.newLifeScore += scoreValue;
			ScoreTracker.superScore += scoreValue;
			ScoreTracker.score += scoreValue;
			Debug.Log (scoreValue);

      GameObjectUtil.Destroy(gameObject);
    }
	}
}
