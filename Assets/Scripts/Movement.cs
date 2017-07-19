using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float moveSpeed;
	public float jumpVel;
	public float glideFallVel;


	private float minusValue = 0.1f;
	bool onFloor = false;

	void movement(){
		float currentYVel = GetComponent<Rigidbody2D> ().velocity.y;
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, currentYVel);
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, currentYVel);
			GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, currentYVel);
		}

		float currentXVel = GetComponent<Rigidbody2D> ().velocity.x;
		if (Input.GetKey (KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) {
			if (onFloor) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentXVel, jumpVel);
			}
		}
	}

	void glide(){
		float currentXVel = GetComponent<Rigidbody2D> ().velocity.x;
		float currentYVel = GetComponent<Rigidbody2D> ().velocity.y;
		if (Input.GetKey (KeyCode.LeftShift)) {
			float tempVel = 0;
			if (currentYVel > -glideFallVel) {
				tempVel = currentYVel - minusValue;
			}
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentXVel, tempVel);
		}
	}


	// Update is called once per frame
	void Update () {
		movement ();
		glide ();


	}
	void OnTriggerEnter2D(Collider2D coll){
		onFloor = true;
		GetComponent<Rigidbody2D> ().gravityScale = 1;
	}
	void OnTriggerExit2D(Collider2D coll){
		onFloor = false;
	}
}
