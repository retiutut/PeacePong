using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	private AudioSource pongSound;
	private Rigidbody2D rb2d;
	private bool ballIsStopped = true;

	public void GoBall() {

		if (!ballIsStopped)
        {
			return;
        }

		float rand = Random.Range (0, 2);
		if (rand < 1) {
			rb2d.AddForce (new Vector2 (25, -10));
		} else {
			rb2d.AddForce (new Vector2 (-25, -10));
		}

		ballIsStopped = false;
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		pongSound = GetComponent<AudioSource>();
	}

	public void ResetBall() {
		rb2d.velocity = new Vector2 (0, 0);
		transform.position = Vector2.zero;
		ballIsStopped = true;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.collider.CompareTag ("Player")) {
			Vector2 vel;
			vel.x = rb2d.velocity.x;
			//The following line makes for more variable ball speed depending on how the ball strikes the paddles
			//vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
			vel.y = rb2d.velocity.y; //Constant ball speed for X and Y axes
			rb2d.velocity = vel;

			float pan = coll.gameObject.name == "Paddle1" ? -1f : 1f;
			pongSound.panStereo = pan;
			pongSound.Play();
		}
	}

	public bool BallIsStopped()
    {
		return ballIsStopped;
    }

}
