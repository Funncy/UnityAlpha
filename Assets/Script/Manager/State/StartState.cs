using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : GameState {

	private GameManager gameManager;
	private List<GameObject> listMonster;
	float timer;


	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
		listMonster = gameManager.getListMonster ();
	}

	public override void Restart(){
	}

	public override void Update () {
		timer += Time.deltaTime;
		if (timer > 1f) {
			if (!listMonster[0].GetComponent<Monster>().isRunning()) 
			gameManager.ChangeState ((int)State.Data.PushState);
		}
	}

	public override void Inputkey(char key){
		
	}
}
