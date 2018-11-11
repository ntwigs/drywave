using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour {

	public GameObject rain;
	public float spawnRate;
	private float nextSpawn;

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			Instantiate(rain, new Vector3(0, 0), Quaternion.identity);
			nextSpawn = Time.time + spawnRate;
		}
	}
}
