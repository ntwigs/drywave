using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstance : MonoBehaviour {
	private BoxCollider2D collider;

	void Start () {
		collider = GetComponent<BoxCollider2D>();
		double verticalSize   = Camera.main.orthographicSize * 2.0;
		double horizontalSize = verticalSize * Screen.width / Screen.height;
		collider.size = new Vector2((float)horizontalSize, 1f);
		transform.position = new Vector2(transform.position.x, -(float)verticalSize / 2 - collider.size.y);
	}
	
	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "rain(Clone)") {
			Destroy(collider.gameObject);
		}
	}
}
