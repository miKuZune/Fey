using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFall : MonoBehaviour {

	private bool despawnable;
	public float despawnTimer;
	// Use this for initialization
	void Start () {
		despawnable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (despawnable == true) {
			despawnTimer -= Time.deltaTime;
			if (despawnTimer <= 0) {
				Destroy (this.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = 1;
			despawnable = true;
		}
	}
}
