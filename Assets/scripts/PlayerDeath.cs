using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Destroy (other.gameObject);
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame


	void Update () {
	
	}
}
