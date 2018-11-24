using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	
	public Animator transitionAnimation;

	public void RestartGame() {
		transitionAnimation.SetTrigger("end");
		StartCoroutine(LoadScene());
	}

	IEnumerator LoadScene () {
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
