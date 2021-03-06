﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public GameObject protector;
	public GameObject points;
	public GameObject title;
	public GameObject play;
	private Animator animator;

	private bool exists = false;
	private Score score;
	private SpawnRain spawnRain;

	void Awake() {
		animator = gameObject.GetComponent<Animator>();
		score = points.GetComponent<Score>();
		spawnRain = gameObject.GetComponentInChildren<SpawnRain>();
	}

	private void PlayGame () {
		Destroy(protector);
	}

	void Update () {
		int i = 0;

		while(i < Input.touchCount) {
			PlayGame();
			spawnRain.setHasStarted();
			score.setHasStarted(true);
			StartCoroutine(RemoveMenu());
			i++;
		}
	}	

	IEnumerator RemoveMenu () {
		animator.SetTrigger("end");
		yield return new WaitForSeconds(1f);
		Destroy(title);
		Destroy(play);
	}

	void FixedUpdate () {
		#if UNITY_EDITOR
		if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) {
			PlayGame();
			spawnRain.setHasStarted();
			score.setHasStarted(true);
			StartCoroutine(RemoveMenu());
		}
		#endif
	}
}
