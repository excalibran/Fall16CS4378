using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer>();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime / 10f;
		mat.mainTextureOffset = offset;
	}
}
