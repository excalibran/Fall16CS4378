using UnityEngine;
using System.Collections;

public class DestroyOffscreen : MonoBehaviour {

  public float offset = 16f;

  private bool offscreen;
  private float offscreenY = 0;
  private Rigidbody2D body2d;

  public delegate void OnDestroy();
  public event OnDestroy DestroyCallback;

  void Awake() {
      body2d = GetComponent<Rigidbody2D>();
  }

	// Use this for initialization
	void Start () {
        offscreenY = (Screen.height / PixelPerfectCamera.pixelsToUnits);
	}
	
	// Update is called once per frame
	void Update () {
    var posy = transform.position.y;
    var diry = body2d.velocity.y;

    if (Mathf.Abs(posy) > offscreenY) {
        if (diry < 0 && posy < offscreenY){
            offscreen = true;
        } else if (diry > 0 && posy > offscreenY) {
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
