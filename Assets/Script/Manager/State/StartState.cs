using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameState {

	private GameManager gameManager;

	float timer;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Restart(){
	}

	public override void Update () {
		timer += Time.deltaTime;
		if (timer > 4f) {
			print ("change push mode");
			gameManager.ChangeState (GameState.PushState);
		}
	}

	public override void Inputkey(char key){

	}
}
