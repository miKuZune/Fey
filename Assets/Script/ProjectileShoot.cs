﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour {

	public float projectileMoveSpeed;
	public float timeToDespawn;
	private bool despawnable;
	// Use this for initialization
	void Start () {
		despawnable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (despawnable == true) {
			timeToDespawn -= Time.deltaTime;
			if (timeToDespawn <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-projectileMoveSpeed, 0);
			despawnable = true;
		} 
	}
}
