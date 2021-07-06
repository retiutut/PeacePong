using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static int playerScore1 = 0;
	public static int playerScore2 = 0;

	private GameObject theBall;
	public static Text leftScoreText;
	public static Text rightScoreText;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
		leftScoreText = GameObject.Find("LeftScore").GetComponent<Text>();
		rightScoreText = GameObject.Find("RightScore").GetComponent<Text>();
	}

	public static void Score(string wallID) {
		if (wallID == "RightWall") {
			playerScore1++;
			leftScoreText.text = playerScore1.ToString();
		} else {
			playerScore2++;
			rightScoreText.text = playerScore2.ToString();
		}
	}

	void OnGUI() {

		/*
		var centeredStyle = GUI.skin.GetStyle("Label");
		centeredStyle.alignment = TextAnchor.UpperCenter;
		//GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2 - 25, 120, 50), "BLAH", centeredStyle);
		GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 50), "" + PlayerScore1, centeredStyle);
		GUI.Label(new Rect(Screen.width / 2 + 50, 20, 100, 50), "" + PlayerScore2, centeredStyle);
		*/

		/*
		var centeredStyleButton = GUI.skin.GetStyle("Button");
		centeredStyleButton.alignment = TextAnchor.MiddleCenter;
		if (GUI.Button (new Rect (Screen.width / 2 - 60, 20, 120, 50), "STOP", centeredStyleButton)) {
			PlayerScore1 = 0;
			PlayerScore2 = 0;
			theBall.SendMessage ("ResetBall", 0.5f, SendMessageOptions.RequireReceiver);
		}
		*/

		if (playerScore1 == 10) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		} else if (playerScore2 == 10) {
			GUI.Label (new Rect (Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
			theBall.SendMessage ("ResetBall", null, SendMessageOptions.RequireReceiver);
		}
	}

	public static void ResetScores()
    {
		playerScore1 = 0;
		playerScore2 = 0;
		leftScoreText.text = playerScore1.ToString();
		rightScoreText.text = playerScore2.ToString();
	}
}
