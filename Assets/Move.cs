using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed = 300;
	public GameObject character;
	private Rigidbody2D characterBody;
	private float ScreenWidth;

	// Use this for initialization
	void Start () {
		ScreenWidth = Screen.width;
		characterBody = character.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;

		while(i < Input.touchCount) {
			if (Input.GetTouch(i).position.x > ScreenWidth / 2) {
				MoveCharacter(1.0f);
			}
			
			if (Input.GetTouch(i).position.x < ScreenWidth / 2) {
				MoveCharacter(-1.0f);
			}

			i++;
		}
	}

	void FixedUpdate() {
		#if UNITY_EDITOR
		Debug.Log("ENTER");
		MoveCharacter(Input.GetAxis("Horizontal"));
		#endif
	}

	private void MoveCharacter(float horizontalInput) {
		characterBody.AddForce(new Vector2(horizontalInput * speed * Time.deltaTime, 0));
	}
}
