using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour {
	public void setFinalScore (string score) {
		Text restartScoreText = gameObject.transform.Find("Score").GetComponent<Text>();
		restartScoreText.text = "" + score;
	}
	public void setHighscore (string score) {
		Text restartScoreText = gameObject.transform.Find("Highscore").GetComponent<Text>();
		restartScoreText.text = "" + score;
	}

	public void setColor () {
		Text restartScoreText = gameObject.transform.Find("HighscoreText").GetComponent<Text>();
		restartScoreText.color = new Color32(222, 205, 158, 255);
	}
}
