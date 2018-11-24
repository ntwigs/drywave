using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {
	string BEST = "best";

	public int SetScore (int score) {
		if (PlayerPrefs.HasKey(BEST)) {
			int highscore = PlayerPrefs.GetInt(BEST);
			if (highscore < score) {
				PlayerPrefs.SetInt(BEST, score);
				return score;
			}
			return highscore;
		}

		PlayerPrefs.SetInt(BEST, score);
		return score;
	}
}
