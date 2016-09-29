using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameoverScoreText, gameoverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameoverPanel, readyButton;
	// Use this for initialization
	void Awake () {
		MakeInstance();
	}

	void Start(){
		Time.timeScale = 0f;
	}
	
	void MakeInstance(){
		if(instance == null){
			instance = this;
		}
	}

	public void SetScore(int score){
		scoreText.text = "x" + score;
	}

	public void SetCoinScore(int score){
		coinText.text = "x" + score;
	}

	public void SetLifeScore(int score){
		lifeText.text = "x" + score;
	}

	public void PauseTheGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive(true);
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive(false);
	}

	public void QuitGame(){
		Time.timeScale = 1f;
		Application.LoadLevel("MainMenu");
	}

	public void GameOverShowPanel(int finalScore, int finalCoinScore){
		gameoverPanel.SetActive(true);
		gameoverScoreText.text = finalScore.ToString();
		gameoverCoinText.text = finalCoinScore.ToString();
		StartCoroutine(GameOverLoadMainMenu());
	}

	public void PlayerDiedRestartTheGame(){
		StartCoroutine(PlayerDiedRestart());
	}

	IEnumerator GameOverLoadMainMenu(){
		yield return new WaitForSeconds(3f);
		Application.LoadLevel("MainMenu");
	}

	IEnumerator PlayerDiedRestart(){
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("Gameplayer");
	}

	public void StartTheGame(){
		Time.timeScale = 1f;
		readyButton.SetActive(false);
	}
}
