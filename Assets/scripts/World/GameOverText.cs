using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour {

	Text gameOverTxt;
  
	public static bool gameOver;
  public bool restart;

	void Start () {
		gameOverTxt = gameObject.GetComponent<Text> ();
		gameOver = false;
	}
	
	void Update () {
    if (gameOver)
    {
      gameOverTxt.text = "Game Over";
    }
    else {
      gameOverTxt.text = "";
    }
	}
}
