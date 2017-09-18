using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : GameState {

	private GameManager gameManager;
	private List<GameObject> listMonster;

	GameObject monster;

	public float speed = 10f;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Restart(){
		listMonster = gameManager.getListMonster ();
	}

	public override void Update () {
		print ("push"+ listMonster.Count);

		print ("push monster " + listMonster [0].transform.position.x);

		if (listMonster [0].transform.position.x > -2) {  

			for (int i = 0; i < listMonster.Count; i++) {

				listMonster [i].transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
		} else {
			gameManager.ChangeState (GameState.AttackState);
		}


	}

	public override void Inputkey(char key){
		
	}
}
