using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainExplode : MonoBehaviour {
	public ParticleSystem emitter;
	private float verticalSize;

	void Start () {
		verticalSize = Camera.main.orthographicSize * 2.0f;
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "InstanceDestroyer") {
			float horizontalPosition = transform.position.x;
			Instantiate(emitter, new Vector2(horizontalPosition, -verticalSize / 2), Quaternion.identity);
		}

		if (collider.gameObject.name == "Protector") {
			Destroy(gameObject);
		}

		if (collider.gameObject.name == "Force") {
			float horizontalPosition = transform.position.x;
			float verticalPosition = transform.position.y;
			Destroy(gameObject);
			Instantiate(emitter, new Vector2(horizontalPosition, verticalPosition), Quaternion.identity);
		}
	}
}
