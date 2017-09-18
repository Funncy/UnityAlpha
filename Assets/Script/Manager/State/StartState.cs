using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameState {

	private GameManager gameManager;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Update () {
		
	}

	public override void Inputkey(char key){

	}
}
