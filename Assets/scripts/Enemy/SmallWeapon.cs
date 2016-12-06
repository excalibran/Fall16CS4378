using UnityEngine;
using System.Collections;

public class SmallWeapon : MonoBehaviour {

  public GameObject shotType;
  public GameObject reactShotType;
  public RaycastHit2D reactDetect;

  public Vector2 reactDirection;

  public float setReactMax;
  private float _reactDelayMin = 0;
  public float reactDelayMin {
    get { return _reactDelayMin; }
  }

  private float _reactDelayMax;
  public float reactDelayMax {
    get { return _reactDelayMax; }
    set
    {
      if (reactDelayMax > _reactDelayMin)
      {
        _reactDelayMax += value;
      }
    }
  }

  private float _normalDelay;
  public float normalDelay {
    get { return _normalDelay; }
    set
    {
      if (_normalDelay <= 0)
      {
        _normalDelay = 3;
      }
    }
  }

  // Use this for initialization
  void Start () {
    StartCoroutine(regularShot());
    reactDelayMax = 3;
    normalDelay = 3;
	}

  void FixedUpdate() {
    reactDetect = Physics2D.Linecast(transform.position, new Vector2(transform.position.x,transform.position.y - 24), 1<<8);
    if (reactDetect) {
      Debug.Log("fire!");
      StartCoroutine(reactShot());
    }
  }	
  /**/
  IEnumerator regularShot() {
    yield return new WaitForSeconds(normalDelay);

    GameObjectUtil.Instantiate(shotType, transform.position);
    StartCoroutine(regularShot());
  }

  IEnumerator reactShot()
  {
    yield return new WaitForSeconds(Random.Range(reactDelayMin, reactDelayMax));

    if (gameObject.activeSelf) {
      GameObjectUtil.Instantiate(shotType, transform.position);
    }
  }
  /*
  
  void OnDestroy() {
    reactDelayMax -= 0.1f;
    reactDelayMin -= 0.1f;
  }
  */
}
