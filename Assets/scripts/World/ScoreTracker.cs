﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 superScore is a remnant of an unimplemented game mechanic
   */

public class ScoreTracker : MonoBehaviour {

	Text scoreTxt;

	public static int score;
	public static int newLifeScore;
	public static int superScore;

	// Use this for initialization
	void Start () {
		scoreTxt = gameObject.GetComponent<Text> ();
		score = 0;
		newLifeScore = 0;
		superScore = 0;
	}

	// Update is called once per frame
	void Update () {
		updateScores ();

	}

	public void updateScores(){

		scoreTxt.text = "Score: " + score;

		if (newLifeScore >= 50) {
			LifeTracker.lives++;
			newLifeScore = 0;
		}

		if (superScore >= 20) {
			superScore = 0;
		}
	}
}