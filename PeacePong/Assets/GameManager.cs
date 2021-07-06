using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static int PlayerScore1 = 0;
	public static int PlayerScore2 = 0;

	public GUISkin layout;

	GameObject theBall;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
	}

	public static void Score(string wallID) {
		if (wallID == "RightWall") {
			PlayerScore1++;
		} else {
			PlayerScore2++;
		}
	}

	void OnGUI() {
		GUI.skin = layout;
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		//GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 25, 120, 50), "BLAH", centeredStyle);
		GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 50), "" + PlayerScore1, centeredStyle);
		GUI.Label(new Rect(Screen.width / 2 + 50, 20, 100, 50), "" + PlayerScore2, centeredStyle);

		var centeredStyleButton = GUI.skin.GetStyle("Button");
		centeredStyleButton.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (Screen.width / 2 - 60, 20, 120, 50), "STOP", centeredStyleButton)) {
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.SendMessage ("ResetBall", 0.5f, SendMessageOptions.RequireReceiver);
		}

		if (PlayerScore1 == 10) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		} else if (PlayerScore2 == 10) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}

}
