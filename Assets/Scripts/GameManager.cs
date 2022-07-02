using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public TextMeshProUGUI timeText;
	public TextMeshProUGUI playerScoreText;
	public TextMeshProUGUI enemyScoreText;
	public TextMeshProUGUI resultText;
	public TextMeshProUGUI winLoseText;
	public GameObject result;
	public GameObject winLose;
	public GameObject home;

	public float totalTime;
	int seconds;

	public int addScore;
	int playerScore = 0;
	int enemyScore = 0;

	bool resultBool = false;

	bool homeBool = false;

	// Use this for initialization
	void Start () {
		playerScoreText.text = "Score " + playerScore.ToString();
		enemyScoreText.text = "Score" + enemyScore.ToString();
	}

	// Update is called once per frame
	void Update () {
		if (totalTime > 0) {
			totalTime -= Time.deltaTime;
			seconds = (int)totalTime;
			timeText.text= seconds.ToString();
		} else if (resultBool == false) {
			Destroy(GameObject.Find("Sphere"));
			Destroy(GameObject.Find("PlayerPink"));
			Destroy(GameObject.Find("Enemy"));
			Destroy(GameObject.Find("Time"));
			Destroy(GameObject.Find("Score"));
			resultText.text = resultText.text + playerScore.ToString();
			if (playerScore > enemyScore) {
				winLoseText.text = "Win!";
			} else if (playerScore < enemyScore) {
				winLoseText.text = "Lose";
			} else {
				winLoseText.text = "Draw";
			}
			result.SetActive(true);
			winLose.SetActive(true);
			home.SetActive(true);
			resultBool = true;
		}

		if (resultBool & !homeBool) {
			if (Input.GetKeyDown("return")) {
				SceneManager.LoadScene("StartScene");
				homeBool = true;
			}
		}
	}

    public void AddPlayerScore(int val) {
        playerScore += val;
        playerScoreText.text = "Score " + playerScore.ToString();
    }

	public void AddEnemyScore(int val) {
        enemyScore += val;
        enemyScoreText.text = "Score " + enemyScore.ToString();
    }
}
