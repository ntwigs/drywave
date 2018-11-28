using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	// public CircleCollider2D collider;
	public GameObject protector;
	public GameObject points;
	public GameObject title;
	public GameObject play;
	public KeepMusic keepMusic;

	private bool exists = false;
	private Score score;

	void Awake() {
		keepMusic.PlayMusic();
		score = points.GetComponent<Score>();
	}

	private void PlayGame () {
		Destroy(protector);
	}

	void Update () {
		int i = 0;

		while(i < Input.touchCount) {
			PlayGame();
			score.setHasStarted(true);
			Destroy(title);
			Destroy(play);
			i++;
		}
	}	

	void FixedUpdate () {
		#if UNITY_EDITOR
		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) {
			PlayGame();
			score.setHasStarted(true);
			Destroy(title);
			Destroy(play);
		}
		#endif
	}
}
