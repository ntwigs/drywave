using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcePush : MonoBehaviour {
	public Animator transitionAnimation;
	public GameObject character;
	private CircleCollider2D forceCircle;
	private SpriteRenderer characterSprite;
	private int power = 0;	

	void Awake () {
		characterSprite = character.GetComponent<SpriteRenderer>();
		forceCircle = GetComponent<CircleCollider2D>();
	}

	public void updatePower () {
		float random = Random.RandomRange(0f, 2f);

		if (power < 10 && random < 0.5) {
			power += 1;
		}
	}

	public void forcePush () {
		setPowerColor();
		followCharacter();
	}

	private void followCharacter () {
		if (gameObject && character) {
			gameObject.transform.position = character.transform.position;
		}
	}

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name != "rain(Clone)") {
			Physics2D.IgnoreCollision(collider.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
		}
	}
	private int test = 0;

	public void setPowerColor () {
		if (power == 10 && characterSprite) {
			test += 2;
			forceCircle.radius = test;
			if (test == 50) {
				transitionAnimation.SetTrigger("force");
				power = 0;
				test = 0;
				forceCircle.radius = test;
			}
		}
	}

	void Update () {
		forcePush();
	}
}