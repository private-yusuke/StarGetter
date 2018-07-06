using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenSprite : MonoBehaviour {
	public float speed = 0.05f;
	public List<AudioClip> audioClip = new List<AudioClip>();
	public Gui gui;
	// Use this for initialization
	void Awake () {
		//rb2d = GetComponent<Rigidbody2D> ();
		gui = FindObjectOfType<Gui>();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(0, -gui.getSpeed(), 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			OnTouchPlayer (other);
		}
	}

    public void playSound(int i) {
        gui.GetComponent<AudioSource>().PlayOneShot(audioClip[i]);
    }

	public virtual void OnTouchPlayer(Collider2D other) {
		
	}
}