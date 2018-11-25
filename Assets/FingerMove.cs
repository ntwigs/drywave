using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMove : MonoBehaviour {
	private Rigidbody2D character;
	private Vector3 position;
	private Vector3 direction;
	private float speed = 50f;
	

	void Awake () {
		character = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			position = Camera.main.ScreenToWorldPoint(touch.position);
			position.z = 0;
			direction = (position - transform.position);
			character.velocity = new Vector2(direction.x, 0) * speed;

			if (touch.phase == TouchPhase.Ended) {
				character.velocity = Vector2.zero;
			}
		}		
	}
}
