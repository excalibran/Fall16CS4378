using UnityEngine;
using System.Collections;

  /*
 Destroys the object it is attached to when it meets certain position and velocity requirements. Became redundant as project
 progressed and some objects had different requirements than others, requiring ad hoc solutions
 */

public class DestroyOffscreen : MonoBehaviour {

  public float offset = 16f;

  private bool offscreen;
  private float offscreenY = 0;
  private float offscreenX = 0;
  private Rigidbody2D body2d;

  public delegate void OnDestroy();
  public event OnDestroy DestroyCallback;

  void Awake() {
      body2d = GetComponent<Rigidbody2D>();
  }

	// Use this for initialization
	void Start () {
        offscreenY = (Screen.height / PixelPerfectCamera.pixelsToUnits + offset);
        offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits + offset);
	}
	
	// Update is called once per frame
	void Update () {
    var posy = transform.position.y;
    var diry = body2d.velocity.y;
    var posx = transform.position.x;
    var dirx = body2d.velocity.x;

    if (Mathf.Abs(posy) > offscreenY) {
      if (diry < 0 && posy < offscreenY) {
        offscreen = true;
      } else if (diry > 0 && posy > offscreenY) {
        offscreen = true;
      }
    }
    else if (Mathf.Abs(posx) > offscreenX)
    {
      if (dirx < 0 && posx < offscreenX)
      {
        offscreen = true;
      }
      else if (dirx > 0 && posx > offscreenX)
      {
        offscreen = true;
      }
    }
    else {
      offscreen = false;
    }

    if (offscreen) {
        OnOutOfBounds();
    }
	}

    public void OnOutOfBounds() {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);

      if (DestroyCallback != null) {
        DestroyCallback();
      }
    }
}
