using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb2d;
	Gui gui;
	public float flap = 550f;
	public float scroll = 10f;
	public float speed = 1f;
	float direction = 0f;

	private bool wasOkusuri = false;
	private ParticleSystem particle;

	bool jump = false;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		gui = FindObjectOfType<Gui> ();
		particle = GetComponentsInChildren<ParticleSystem> ()[0];
		particle.Stop ();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		if (!wasOkusuri) {
			if (gui.isOkusuri) {
				wasOkusuri = true;
				particle.Play ();
			}
		} else if (!gui.isOkusuri) {
			wasOkusuri = false;
			particle.Stop ();
		}

        if (Input.GetKeyDown (KeyCode.Space) && !jump) {
			rb2d.AddForce (Vector2.up * flap);
			jump = true;
		}

		float tmpspeed = speed;
		if (gui.isOkusuri) {
			tmpspeed *= -2;
		}

		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
			tmpspeed /= 2;
		
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			direction = tmpspeed;
        else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			direction = -tmpspeed;
		else
			direction = 0f;
		
		rb2d.velocity = new Vector2 (scroll * direction, rb2d.velocity.y);

	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag ("Ground"))
			jump = false;
	}
}
