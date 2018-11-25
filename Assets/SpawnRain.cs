using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRain : MonoBehaviour {

	public GameObject rain;
	public float maxSpawnRate;
	public float spawnRate;
	private float nextSpawn;

	private float height;
	private float width;

	void Start () {
		double verticalSize   = Camera.main.orthographicSize * 2.0;
		double horizontalSize = verticalSize * Screen.width / Screen.height;	
		height = (float)verticalSize;
		width = (float)horizontalSize;
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawn) {
			float spawnY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y + 1;
			float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
			Vector2 spawnPosition = new Vector2(spawnX, spawnY);

			Instantiate(rain, spawnPosition, Quaternion.identity);
			nextSpawn = Time.time + spawnRate;
		}
		updateSpawnRate();
	}

	void updateSpawnRate() {
		if (spawnRate > maxSpawnRate) {
			spawnRate -= 0.001f;
		} 
	}
}
