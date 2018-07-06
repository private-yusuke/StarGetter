using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOkusuri : FallenSprite {

	public override void OnTouchPlayer (Collider2D other)
	{
		Destroy (this.gameObject);
        playSound(0);
        gui.Okusuri();
	}
}
