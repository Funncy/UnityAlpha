using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GameState {

	private GameManager gameManager;

	private float timer;
	private List<GameObject> listMonster;

	private bool isAttacked;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
		listMonster = gameManager.getListMonster ();
	}

	public override void Restart(){
		isAttacked = false;
		timer = 0;
	}

	public override void Update () {
		//Time.timeScale = 1f;
		timer += Time.deltaTime;
		//print ("timer = " + timer);
		if (timer > 1f) {
			print ("change push mode");
			//Time.timeScale = 1f;

			if (isAttacked) {
				listMonster [0].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (500, 1000));
				listMonster.RemoveAt (0);

				//all monster clear
				if (listMonster.Count == 0)
					gameManager.ChangeState ((int)State.Data.EndState);
				else
					gameManager.ChangeState ((int)State.Data.PushState);
			} else {
				print ("fail");
				gameManager.ChangeState ((int)State.Data.FailState);
			}
		}
	}

	public override void Inputkey(char key){

	}
}
