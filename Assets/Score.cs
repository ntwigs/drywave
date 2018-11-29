using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text text;
	public ForcePush forcePush;
	private int score;
	public float pointRate;
	private float nextPoint;
	private bool hasStarted = false;
	private bool gameOver = false;
	private Animator animator;

	public bool getHasStarted () {
		return hasStarted;
	}

	public void setGameOver () {
		gameOver = true;
	}

	public void setHasStarted (bool hasStarted) {
		this.hasStarted = hasStarted;
	}

	public int getScore () {
		return score;
	}

	public void removePoints () {
		StartCoroutine(RemoveScore());
	}

	IEnumerator RemoveScore () {
		animator.SetTrigger("hide");
		yield return new WaitForSeconds(1f);
		text.text = "";
	}

	IEnumerator DisplayScore () {
		animator.SetTrigger("display");
		yield return new WaitForSeconds(1f);
	}

	void Start () {
		animator = gameObject.GetComponentInParent<Animator>();
		text = GetComponent<Text>();
		score = 0;
	}

	void Update () {
		if (hasStarted) {
			StartCoroutine(DisplayScore());
		}
		if (Time.time > nextPoint & hasStarted & !gameOver) {
			text.text = "" + score;
			this.AddPoints();
			nextPoint = Time.time + pointRate;
		}
	}

	void AddPoints () {
		score += 1;
		forcePush.updatePower();
	}
}
