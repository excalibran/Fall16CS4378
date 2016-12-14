using UnityEngine;
using System.Collections;

/*
 This class is responsible for enemy craft that attempt to avoid colliding with the player. It uses a collision volume to detect the player's presence 
 and then uses the player's position to create a normalized vector that is added to normal movement. This calculation has been simplified
 from the one shown in the presentation, as the first calculation was intended to feel less perfect. However, the movement just looked and felt 'bad',
 so it has been altered to match the text's Avoid solution.
*/

public class AvoidPlayerCollision : MonoBehaviour {

  public Vector2 dodgeModifier;

	void Start () {
    dodgeModifier = Vector2.zero;
	}

  void OnTriggerEnter2D(Collider2D coll)
  {
    if (coll.gameObject.tag == "Player")
    {
      /*
       This is the calculation that has been simplified, and is not more like the text's Avoid behavior.
       */
      Rigidbody2D collrig = coll.gameObject.GetComponent<Rigidbody2D>();
      Vector2 current = transform.position;

      dodgeModifier = (current - collrig.position).normalized;
    }
  }

  void OnTriggerExit2D(Collider2D coll)
  {
    if (coll.gameObject.tag == "Player")
    {
      dodgeModifier = Vector2.zero;
    }
  }

  void OnDisable() {
    dodgeModifier = Vector2.zero;
  }
}
