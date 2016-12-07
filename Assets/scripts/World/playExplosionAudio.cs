using UnityEngine;
using System.Collections;

public class playExplosionAudio : MonoBehaviour {
	
	public AudioSource explodeSource;
	public AudioClip explodeClip;

	// Use this for initialization
	void Start () {
		explodeSource.clip = explodeClip;
		explodeSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
