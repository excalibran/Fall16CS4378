using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

  public GameObject explode;

	// Use this for initialization
	void Start () {
    
	}
  //other.tag == "Enemy" || 
  void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "EnemyShot" || other.tag == "Mine") {
      GameObjectUtil.Instantiate(explode, transform.position);
      gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame

}
