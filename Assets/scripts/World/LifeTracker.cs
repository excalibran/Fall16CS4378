using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 Sadly, there is no 'game manager' object. This is as close as it gets. It keeps a reference to the player object
 and reactivates it of the player makes an input. The gameOver variable exists in several other objects and manages their
 states.
   */

public class LifeTracker : MonoBehaviour {

	Text lifeTxt;
	public static int lives;
  private GameObject player;

	public static int score;

  void Start () {
		lifeTxt = gameObject.GetComponent<Text> ();
		lives = 3;
    player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		lifeTxt.text = "x  " + lives;

		if (lives <= 0) {
			GameOverText.gameOver = true;
      if (Input.GetButtonDown("Fire1")) {
        player.SetActive(true);
        lives = 3;
        GameOverText.gameOver = false;
        ScoreTracker.score = 0;
      }
		}
	}
}
