using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	/*
   creates scrolling effect fo star background
  */
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer>();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime / 10f;
		mat.mainTextureOffset = offset;
	}
}
