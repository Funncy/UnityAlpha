using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndState : GameState {

	// Use this for initialization
	private GameManager gameManager;


	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Restart(){
		
	}

	public override void Update () {
	}

	public override void Inputkey(char key){
	}
}
