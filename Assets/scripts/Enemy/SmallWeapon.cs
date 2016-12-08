using UnityEngine;
using System.Collections;

public class SmallWeapon : MonoBehaviour {

  public GameObject shotType1;
  public GameObject shotType2;

  public int normalFire;
  public int setMax;
  
  private float _delayMax;
  public float delayMax
  {
    get { return _delayMax; }
    set
    {
      if (_delayMax <= 0)
      {
        _delayMax = setMax;
      }
    }
  }

  // Use this for initialization
  void Start () {
    delayMax = setMax;
	}

  void FixedUpdate() {

    if (normalFire <= 0) {
      if (shotType1) {
        GameObjectUtil.Instantiate(shotType1, transform.position);
      }
      if (shotType2) {
        GameObjectUtil.Instantiate(shotType2, transform.position);
      }
      normalFire = (int)delayMax;
    }
    else
    {
      normalFire--;
    }
  }
}
