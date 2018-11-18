using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
	public Canvas gameOverMenu;
	public Text score;
	public Canvas counter;

	void OnCollisionEnter2D (Collision2D collider) {
		if (collider.gameObject.name == "rain(Clone)") {
			Destroy(collider.gameObject);
			Destroy(gameObject);

			Canvas gameOverMenuInstance = Instantiate(gameOverMenu, new Vector2(0, 0), Quaternion.identity);
			RestartMenu gameOverMenuScript = gameOverMenuInstance.GetComponent<RestartMenu>();
			gameOverMenuScript.setFinalScore(score.text);

			Score scoreScript = score.GetComponent<Score>();
			scoreScript.setHasStarted(false);
			scoreScript.setGameOver();
			scoreScript.removePoints();

		}
	}
}