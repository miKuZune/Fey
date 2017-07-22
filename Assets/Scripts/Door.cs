using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public GameObject keyToDoor;

	// Update is called once per frame
	void Update () {
			
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player" && keyToDoor == null ) {
			Destroy (gameObject);
		}
	}
}
