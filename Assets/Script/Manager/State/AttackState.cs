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

		if (listMonster [0].transform.position.x > -1.5) {
			if(timer <0.5f )
				//gameManager.ChangeState ((int)State.Data.PushState);
			return;
		}

		if (isAttacked) {
			//print ("isAttacked "+listMonster [listMonster.Count - 1].GetComponent<Monster> ().isRunning ());
			if (listMonster.Count == 0)
				gameManager.ChangeState ((int)State.Data.EndState);
			else if (!listMonster [listMonster.Count - 1].GetComponent<Monster> ().isRunning ()) {
				//print ("Attacked clear Push Start");
				gameManager.ChangeState ((int)State.Data.PushState);
			}
		}else if (timer > 1f) {
				//Time Over  -> fail State	
			if (!listMonster [0].GetComponent<Monster> ().isRunning ())
				//print ("change Fail state");
				gameManager.ChangeState ((int)State.Data.FailState);
			}
		
		
	}

	public override void Inputkey(char key){
		GameObject tmp = listMonster [0];
		float lastPosX = listMonster [listMonster.Count-1].transform.position.x;
		//print ("Inputkey Move X = " + lastPosX);
		//print (" second x = " + listMonster [1].transform.position.x);

		if (lastPosX > 11) {
			tmp.GetComponent<Monster> ().Attacked (11, 0);
		} else {
			tmp.GetComponent<Monster> ().Attacked ( lastPosX + 4, 0);
		}
		listMonster.RemoveAt (0);

		listMonster.Add (tmp);
		//print("new add Monster Index = "+listMonster[listMonster.Count-1].Equals (tmp));

		isAttacked = true;
	}
}
