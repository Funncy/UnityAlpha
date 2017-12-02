using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndState : GameState {

	// Use this for initialization
	private GameManager gameManager;
	public Text ScoreText;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;

	}

	public override void Restart(){
		SceneManager.LoadScene ("ScoreScene");
	}

	public override void Update () {
		
	}

	public override void Inputkey(char key){
	}
}
