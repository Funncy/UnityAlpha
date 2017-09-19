using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : GameState {

	private GameManager gameManager;

	private float timer;

	private List<GameObject> listMonster;


	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
		listMonster = gameManager.getListMonster ();
	}

	public override void Restart(){
		timer = 0;
		print ("Fail State Monster num=" + listMonster.Count);
		foreach(var mons in listMonster){
			mons.GetComponent<Monster> ().Fail ();

		}
	}

	public override void Update () {



		if (!listMonster[0].GetComponent<Monster>().isRunning()) {
			//시간이 지나면 다시 Push State Chnage
			gameManager.ChangeState ((int)State.Data.PushState);
		}

		print ("game Fail");
	}

	public override void Inputkey(char key){

	}
}

