using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp = KeyCode.W;
	public KeyCode moveDown = KeyCode.S;
	public float speed = 30.0f;
	public float boundY = 2.25f;
	private Rigidbody2D rb2d;
	private Vector3 target;
	GameObject theBall;
	BallControl ballScript;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		target = transform.position;
		theBall = GameObject.FindGameObjectWithTag("Ball");
		ballScript = (BallControl)theBall.GetComponent(typeof(BallControl));
	}
	
	// Update is called once per frame
	void Update () {

		bool userInteraction = false;

		//Keyboard Controls
		var vel = rb2d.velocity;
		if (Input.GetKey (moveUp)) {
			vel.y = speed;
			userInteraction = true;
		} else if (Input.GetKey (moveDown)) {
			vel.y = -speed;
			userInteraction = true;
		} else if (!Input.anyKey) {
			vel.y = 0;
		}
		rb2d.velocity = vel;


		//Mouse/Touch Controls
		if (Input.GetMouseButton(0))
		{
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Maintain paddle X position and change Y position only (up/down)
			target.x = transform.position.x;
			target.z = transform.position.z;
			transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
			userInteraction = true;

		}
		
		//Constrain to window size
		var pos = transform.position;
		if (pos.y > boundY) {
			pos.y = boundY;
		} else if (pos.y < -boundY) {
			pos.y = -boundY;
		}
		transform.position = pos;

		bool startGame = ballScript.BallIsStopped() && userInteraction;
		if (startGame)
		{
			theBall.SendMessage("GoBall", 0.5f, SendMessageOptions.RequireReceiver);
		}
	}
}
