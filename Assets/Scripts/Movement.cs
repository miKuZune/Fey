using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float moveSpeed;
	public float jumpVel;
	bool onFloor = false;

	void movement(){
		float currentYVel = GetComponent<Rigidbody2D> ().velocity.y;
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, currentYVel);
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, currentYVel);
		}

		float currentXVel = GetComponent<Rigidbody2D> ().velocity.x;
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown(KeyCode.Z)) {
			if(onFloor)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (currentXVel,jumpVel);
		}
	}


	// Update is called once per frame
	void Update () {
		movement ();


	}
	void OnTriggerEnter2D(Collider2D coll){
		onFloor = true;
	}
	void OnTriggerExit2D(Collider2D coll){
		onFloor = false;
	}
}
