using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPosition : MonoBehaviour {
	public bool isRight = false;
	public BoxCollider2D box;

	void Start () {
		double verticalSize   = Camera.main.orthographicSize * 2.0;
		double horizontalSize = verticalSize * Screen.width / Screen.height;
		float colliderSize = box.size.x;
		if (isRight) {
			float rightPosition = (float)horizontalSize / 2 + colliderSize / 2;
			transform.position = new Vector2(rightPosition, transform.position.y);
		} else {
			float leftPosition = -(float)horizontalSize / 2 - colliderSize / 2;
			transform.position = new Vector2(leftPosition, transform.position.y);
		}
	}
}
