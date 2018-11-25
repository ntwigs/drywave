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
	
	void FixedUpdate() {
		#if UNITY_EDITOR
		MoveCharacter(Input.GetAxis("Horizontal"));
		#endif
	}

	private void MoveCharacter(float horizontalInput) {
		characterBody.AddForce(new Vector2(horizontalInput * speed * Time.deltaTime, 0));
	}
}
