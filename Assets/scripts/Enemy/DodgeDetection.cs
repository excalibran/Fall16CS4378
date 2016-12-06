using UnityEngine;
using System.Collections;

public class DodgeDetection : MonoBehaviour {

  public Vector2 dodgeModifier;
  Vector2 current;

	// Use this for initialization
	void Start () {
    dodgeModifier = Vector2.zero;
    current = transform.position;
	}

  void OnTriggerEnter2D(Collider2D coll)
  {
    if (coll.gameObject.tag == "Player")
    {
      Vector2 calc = Vector2.zero;
      //Debug.Log("bing");
      Rigidbody2D collrig = coll.gameObject.GetComponent<Rigidbody2D>();

      if (collrig.position.y != current.y)
      {
        if (collrig.position.x > current.x) { calc += Vector2.left; }
        else { calc += Vector2.right; }
      }

      if (collrig.position.x != current.x)
      {
        if (collrig.position.y > current.y) { calc += Vector2.down; }
        else { calc += Vector2.up; }
      }
      dodgeModifier = calc.normalized;
    }
  }

  void OnTriggerExit2D(Collider2D coll)
  {
    //Debug.Log("leave");
    if (coll.gameObject.tag == "Player")
    {
      dodgeModifier = Vector2.zero;
    }
  }
}
