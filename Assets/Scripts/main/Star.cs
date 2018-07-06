using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : FallenSprite {

	//Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		//rb2d = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			gui.AddPoint (10);
			
			Destroy (this.gameObject);
            playSound(0);

			//Destroy(other.gameObject);
		}
	}
}
