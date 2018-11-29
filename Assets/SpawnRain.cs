using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour {
	public GameObject rain;
	public float spawnRate;
	private float nextSpawn;
	private float height;
	private float width;
	private bool hasStarted = false;
	private float nextDecrease;
	private float decreaseRate = 8;

	void Start () {
		double verticalSize   = Camera.main.orthographicSize * 2.0;
		double horizontalSize = verticalSize * Screen.width / Screen.height;	
		height = (float)verticalSize;
		width = (float)horizontalSize;
	}

	void Update () {
		if (Time.time > nextSpawn) {
			float spawnY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + 1;
			float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
			Vector2 spawnPosition = new Vector2(spawnX, spawnY);

			Instantiate(rain, spawnPosition, Quaternion.identity);
			nextSpawn = Time.time + spawnRate;
			updateSpawnRate();
		}
	}

	public void setHasStarted() {
		hasStarted = true;
	}

	void updateSpawnRate() {
		if (Time.time > nextDecrease && spawnRate > 0.04 && hasStarted) {
			spawnRate -= 0.02f;
			nextDecrease = Time.time + decreaseRate;
		}
	}
}
