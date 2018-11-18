using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour {
	public void setFinalScore (string score) {
		Text restartScoreText = gameObject.transform.Find("Score").GetComponent<Text>();
		restartScoreText.text = "Score: " + score;
	}
}
