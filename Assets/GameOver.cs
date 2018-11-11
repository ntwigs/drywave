using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "rain(Clone)") {
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}