using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMusic : MonoBehaviour {
	private AudioSource audio;

	void Awake () {
		DontDestroyOnLoad(gameObject);
		audio = GetComponent<AudioSource>();
	}

	public void PlayMusic()
     {
         if (audio.isPlaying) return;
         audio.Play();
     }
 
     public void StopMusic()
     {
         audio.Stop();
     }
}
