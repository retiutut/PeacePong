using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static int playerScore1 = 0;
	private static int playerScore2 = 0;
	private static bool pongModeEnabled = false;

	private GameObject theBall;
	private GameObject allPongObjects;
	private GameObject allEMDRObjects;
	private static Text leftScoreText;
	private static Text rightScoreText;
	private static Button bgMusicButton;
	private static Button gameModeButton;
	public static AudioSource bgMusic;

	// Use this for initialization
	void Start () {
		theBall = GameObject.FindGameObjectWithTag("Ball");
		allPongObjects = GameObject.Find("PongObjects");
		allEMDRObjects = GameObject.Find("EMDRObjects");
		leftScoreText = GameObject.Find("LeftScore").GetComponent<Text>();
		rightScoreText = GameObject.Find("RightScore").GetComponent<Text>();
		bgMusicButton = GameObject.Find("MusicToggle").GetComponent<Button>();
		gameModeButton = GameObject.Find("GameModeToggle").GetComponent<Button>();
		AudioSource[] sounds = GetComponents<AudioSource>();
		bgMusic = sounds[0];

		UpdateUIBasedOnGameMode();
		UpdateBgMusicButtonText();
		UpdateGameModeButtonText();
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

	public static void ToggleBgMusic()
    {
		if (bgMusic == null)
        {
			return;
        }

		if (!bgMusic.isPlaying)
		{
			bgMusic.Play();
		}
        else
        {
			bgMusic.Stop();
        }

		UpdateBgMusicButtonText();
	}

	public void ToggleGameMode()
    {
		pongModeEnabled = !pongModeEnabled;
		UpdateUIBasedOnGameMode();
		UpdateGameModeButtonText();
	}

	private void UpdateUIBasedOnGameMode()
    {
		leftScoreText.gameObject.SetActive(pongModeEnabled);
		rightScoreText.gameObject.SetActive(pongModeEnabled);
		allPongObjects.SetActive(pongModeEnabled);
		allEMDRObjects.SetActive(!pongModeEnabled);
	}

	private static void UpdateBgMusicButtonText()
    {
		string buttonText = bgMusic.isPlaying ? "Sounds" : "Music";
		bgMusicButton.GetComponentInChildren<Text>().text = buttonText;
	}

	private void UpdateGameModeButtonText()
    {
		string buttonText = pongModeEnabled ? "EMDR" : "Pong";
		gameModeButton.GetComponentInChildren<Text>().text = buttonText;
	}

	public static bool GetPongModeEnabled()
    {
		return pongModeEnabled;
    }
}
