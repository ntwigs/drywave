using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForcePush : MonoBehaviour {
	public Animator transitionAnimation;
	public GameObject character;
	public float powerRate;
	public Animator tip;
	private float nextPower;
	
	private CircleCollider2D forceCircle;
	private SpriteRenderer characterSprite;
	private float power = 0;	
	private int forceRange = 0;
	private bool isFirstPlay;

	void Awake () {
		isFirstPlay = !PlayerPrefs.HasKey("isFirstPlay");
		characterSprite = character.GetComponent<SpriteRenderer>();
		forceCircle = GetComponent<CircleCollider2D>();
	}

	public void updatePower () {
		if (Time.time > nextPower && power < 10) {
			power += 1f;
			nextPower = Time.time + powerRate;
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

	public void setPowerColor () {
		if (power == 10 && characterSprite) {
			if (isFirstPlay) {
				StartCoroutine(pause());
			}

			transitionAnimation.SetTrigger("loaded");
			power += 1;
		}

		if (power == 11 && characterSprite && Input.touchCount <= 0) {
			Time.timeScale = 1;
			transitionAnimation.SetTrigger("force");
			if (isFirstPlay) {
				tip.SetTrigger("hide_tip");
				PlayerPrefs.SetInt("isFirstPlay", 1);
				isFirstPlay = false;
			}
			power += 1;
		}

		if (power == 12) {
			forceRange += 10;
			forceCircle.radius = forceRange;
			if (forceRange == 100) {
				power = 0;
				forceRange = 0;
				forceCircle.radius = forceRange;
			}
		}
	}

	IEnumerator pause () {
		tip.SetTrigger("show_tip");
		yield return new WaitForSeconds(0.2f);
		Time.timeScale = 0;
	}

	void Update () {
		forcePush();
	}
}