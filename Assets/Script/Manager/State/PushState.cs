using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushState : GameState {

	private GameManager gameManager;
	private List<GameObject> listMonster;

	GameObject monster;

	public float speed = 1f;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
	}

	public override void Restart(){
		listMonster = gameManager.getListMonster ();
		print ("List Monster Count = " + listMonster.Count);
		print ("List Monster x = " + listMonster [0].transform.position.x);
		Time.timeScale = 5f;
	}

	public override void Update () {

		if (listMonster.Count == 0)
			gameManager.ChangeState (GameState.EndState);

		if (listMonster [0].transform.position.x > -2) {  

			for (int i = 0; i < listMonster.Count; i++) {

				listMonster [i].transform.Translate (Vector3.left * speed * Time.deltaTime);
			}
		} else {
			print ("change AttackMode");
			Time.timeScale = 1f;
			gameManager.ChangeState (GameState.AttackState);
		}


	}

	public override void Inputkey(char key){
		
	}
}
