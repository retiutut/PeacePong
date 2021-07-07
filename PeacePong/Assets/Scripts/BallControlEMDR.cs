﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlEMDR : MonoBehaviour {

	private AudioSource leftPongSound;
	private AudioSource rightPongSound;
	private Rigidbody2D rb2d;
	private bool ballIsStopped = true;

	public void GoBall() {

		if (!ballIsStopped)
        {
			return;
        }

		float rand = Random.Range (0, 2);
		if (rand < 1) {
			rb2d.AddForce (new Vector2 (25, 0));
		} else {
			rb2d.AddForce (new Vector2 (-25, 0));
		}

		ballIsStopped = false;
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		AudioSource[] sounds = GetComponents<AudioSource>();
		leftPongSound = sounds[0];
		rightPongSound = sounds[1];
	}

    private void Update()
    {
		bool startEMDR = ballIsStopped 
			&& !GameManager.GetPongModeEnabled() 
			&& (Input.anyKey || Input.GetMouseButton(0));

		if (startEMDR)
        {
			GoBall();
        }
    }

    public void ResetBall() {

		if (rb2d == null)
        {
			return;
        }

		rb2d.velocity = new Vector2 (0, 0);
		transform.position = Vector2.zero;
		ballIsStopped = true;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.collider.CompareTag("SideWall"))
		{
			bool collidedWithLeftWall = coll.gameObject.name == "LeftWallEMDR";
			float sfxVolume = GameManager.bgMusic.isPlaying ? 0F : 1F;
			if (collidedWithLeftWall)
			{
				leftPongSound.PlayOneShot(leftPongSound.clip, sfxVolume);
			}
			else
			{
				rightPongSound.PlayOneShot(rightPongSound.clip, sfxVolume);

			}
		}
	}

	public bool BallIsStopped()
    {
		return ballIsStopped;
    }

}
