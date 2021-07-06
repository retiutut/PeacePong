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
	public static AudioSource bgMusic;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag ("Ball");
		leftScoreText = GameObject.Find("LeftScore").GetComponent<Text>();
		rightScoreText = GameObject.Find("RightScore").GetComponent<Text>();
		AudioSource[] sounds = GetComponents<AudioSource>();
		bgMusic = sounds[0];
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

	public static void ToggleBgMusic(bool toggleMusic)
    {
		if (bgMusic == null)
        {
			return;
        }

		Debug.Log("MusicToggle: " + toggleMusic);
		if (toggleMusic)
		{
			bgMusic.Play();
		}
        else
        {
			bgMusic.Stop();
        }
	}
}
