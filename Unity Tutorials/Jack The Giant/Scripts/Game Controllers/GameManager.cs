using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	
	public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

	public int score, coinScore, lifeScore;

	// Use this for initialization
	void Awake () {
		MakeSingleton();
	}

	void OnLevelWasLoaded(){
		if(Application.loadedLevelName == "Gameplay"){
			if(gameRestartedAfterPlayerDied){
				GameplayController.instance.SetScore(score);
				GameplayController.instance.SetCoinScore(coinScore);
				GameplayController.instance.SetLifeScore(lifeScore);

				PlayerScore.scoreCount = score;
				PlayerScore.coinCount = coinScore;
				PlayerScore.lifeCount = lifeScore;
			}
			else if(gameStartedFromMainMenu){
				PlayerScore.scoreCount = 0;
				PlayerScore.coinCount = 0;
				PlayerScore.lifeCount = 2;

				GameplayController.instance.SetScore(PlayerScore.scoreCount);
				GameplayController.instance.SetCoinScore(PlayerScore.coinCount);
				GameplayController.instance.SetLifeScore(PlayerScore.lifeCount);
			}
		}
	}
	
	// Update is called once per frame
	void MakeSingleton(){
		if(instance == null){
			Destroy(gameObject);
		}
		else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	public void CheckGameStatus(int score, int coinScore, int lifeScore){
		if(lifeScore < 0){
			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = false;

			GameplayController.instance.GameOverShowPanel(score,coinScore);

		}

		else{
			this.score = score;
			this.coinScore = coinScore;
			this.lifeScore = lifeScore;

			GameplayController.instance.SetScore(score);
			GameplayController.instance.SetCoinScore(coinScore);
			GameplayController.instance.SetLifeScore(lifeScore);

			gameStartedFromMainMenu = false;
			gameRestartedAfterPlayerDied = true;

			GameplayController.instance.PlayerDiedRestartTheGame();
		}
	}
}
