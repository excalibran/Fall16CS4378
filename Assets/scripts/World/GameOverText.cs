using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {

	Text gameOverTxt;



	public static bool gameOver;


	// Use this for initialization
	void Start () {
		gameOverTxt = gameObject.GetComponent<Text> ();
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver) {
			gameOverTxt.text= "Game Over \n press 'Space' to restart";
		}



	}
}
