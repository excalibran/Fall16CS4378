using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	Text scoreTxt;
	public static int score;

	// Use this for initialization
	void Start () {
		scoreTxt = gameObject.GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		scoreTxt.text = "Score: " + score;
	}

}
