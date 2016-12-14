using UnityEngine;
using System.Collections;



public class PlayMainTheme : MonoBehaviour {
	public AudioClip mainClip;
	public AudioSource mainSource;
	public AudioClip deathClip;
	bool deathPlaying;
  
	// Use this for initialization
	void Start () {
		mainSource.clip = mainClip;
		mainSource.Play ();
		deathPlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
    if (GameOverText.gameOver == true && deathPlaying == false)
    {
      mainSource.Stop();
      mainSource.time = 19.2f;
      mainSource.clip = deathClip;
      mainSource.Play();
      deathPlaying = true;
    }

    if (GameOverText.gameOver == false && deathPlaying == true){
      mainSource.Stop();
      mainSource.time = 19.2f;
      mainSource.clip = mainClip;
      mainSource.Play();
      deathPlaying = false;
    }
	
	}
}
