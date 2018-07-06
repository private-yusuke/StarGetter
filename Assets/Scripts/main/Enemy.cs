using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : FallenSprite {

	// Use this for initialization
	void Start () {

	}

	public override void OnTouchPlayer (Collider2D other)
	{
        /*if(!gui.isMoreStar) {
            playSound(0);
            gui.AddHP(-10);
        } else {
            playSound(1);
        }*/
        playSound(0);
        gui.AddHP(-10);

        if (gui.getHP() <= 0)
        {
            Destroy(other.gameObject);
            Debug.Log("dead!");
            FindObjectOfType<Gui>().OnPlayerDead();
        }
		Destroy (this.gameObject);
	}
}
