using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public Text text;
	private int score;
	public float pointRate;
	private float nextPoint;
	private bool hasStarted = false;
	private bool gameOver = false;

	public bool getHasStarted () {
		return hasStarted;
	}

	public void setGameOver () {
		gameOver = true;
	}

	public void setHasStarted (bool hasStarted) {
		this.hasStarted = hasStarted;
	}

	public void removePoints () {
		text.text = "";
	}


	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextPoint & hasStarted & !gameOver) {
			text.text = "" + score;
			this.AddPoints();
			nextPoint = Time.time + pointRate;
		}
	}

	void AddPoints () {
		score += 1;
	}
}
