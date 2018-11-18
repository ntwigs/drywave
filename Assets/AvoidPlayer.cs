using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidPlayer : MonoBehaviour {
	public GameObject player;
	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "character") {
			Physics2D.IgnoreCollision(collider.collider, player.GetComponent<Collider2D>());
		} 
	}
}
