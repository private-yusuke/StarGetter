using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlower : FallenSprite {

	// Use this for initialization
	void Start () {
		//rb2d = GetComponent<Rigidbody2D> ();
	}

	public override void OnTouchPlayer (Collider2D other)
	{
		Destroy (this.gameObject);
        playSound(0);
		gui.SlowStage ();
	}

}
