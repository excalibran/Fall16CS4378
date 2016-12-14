using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PriorityTracker : MonoBehaviour {

  Text txt;
  EnemyProduction en;

	// Use this for initialization
	void Start () {
    txt = gameObject.GetComponent<Text>();
    en = GameObject.FindGameObjectWithTag("Production").GetComponent<EnemyProduction>();
	}
	
	// Update is called once per frame
	void Update () {
    txt.text = en.priority.x + ", " + en.priority.y;
	}
}
