using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D hitInfo) {
		if (hitInfo.name == "Ball")
		{
			string wallName = transform.name;
			GameManager.Score (wallName);
			hitInfo.gameObject.SendMessage ("ResetBall", 1, SendMessageOptions.RequireReceiver);
			//hitInfo.gameObject.SendMessage("GoBall", 2, SendMessageOptions.RequireReceiver);
		}
	}
}
