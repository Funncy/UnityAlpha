using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GameState {

	private GameManager gameManager;

	private float timer;
	private List<GameObject> listMonster;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Restart(){
		listMonster = gameManager.getListMonster ();
	}

	public override void Update () {
		//Time.timeScale = 1f;
		timer += Time.deltaTime;
		//print ("timer = " + timer);
		if (timer > 1f) {
			print ("change push mode");
			//Time.timeScale = 1f;

			listMonster [0].GetComponent<Rigidbody2D> ().AddForce (new Vector2 (500, 1000));
			listMonster.RemoveAt (0);

			gameManager.ChangeState (GameState.PushState);
			timer = 0;

		}
	}

	public override void Inputkey(char key){

	}
}
