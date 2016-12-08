using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeTracker : MonoBehaviour {

	Text lifeTxt;
	public static int lives;

	public static int score;
	// Use this for initialization
	void Start () {
		lifeTxt = gameObject.GetComponent<Text> ();
		lives = 3;
	}

	// Update is called once per frame
	void Update () {
		lifeTxt.text = "x  " + lives;

		if (lives == 0) {
			GameOverText.gameOver = true;
		}

	}
}
