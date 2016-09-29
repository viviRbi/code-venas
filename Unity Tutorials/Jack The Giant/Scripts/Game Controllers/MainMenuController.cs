using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void StartGame(){
		GameManager.instance.gameStartedFromMainMenu = true;
		Application.LoadLevel("Gameplay");
	}

	public void HighscoreMenu(){
		Application.LoadLevel("Highscore");
	}

	public void OptionsMenu(){
		Application.LoadLevel("OptionsMenu");
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void MusicButton(){

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
