 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : FallenSprite {

	// Use this for initialization
	void Start () {
		
	}

	public override void OnTouchPlayer (Collider2D other)
	{
		Destroy (this.gameObject);
        playSound(0);
        gui.AddHP(10);
	}
}