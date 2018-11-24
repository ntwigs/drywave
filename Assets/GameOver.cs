using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Canvas gameOverMenu;
	public GameObject canvas;
	public Text score;
	public Canvas counter;
	public Highscore highscore;

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "rain(Clone)") {
			Destroy(collider.gameObject);
			Destroy(gameObject);

			canvas.SetActive(true);
			RestartMenu gameOverMenuScript = gameOverMenu.GetComponent<RestartMenu>();
			Score scoreScript = score.GetComponent<Score>();

			int currentHighscore = highscore.SetScore(scoreScript.getScore());
			int currentScore = scoreScript.getScore();

			if (currentHighscore == currentScore) {
				gameOverMenuScript.setColor();	
			}

			gameOverMenuScript.setFinalScore("" + currentScore);
			gameOverMenuScript.setHighscore("" + currentHighscore);

			scoreScript.setHasStarted(false);
			scoreScript.setGameOver();
			scoreScript.removePoints();
		}
	}
}