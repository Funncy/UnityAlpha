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
		Time.timeScale = 1f;
		timer += Time.deltaTime;

		if (listMonster.Count == 0)
			gameManager.ChangeState ((int)State.Data.EndState);

		if (listMonster [0].transform.position.x > -1.5) {
			if (timer > 0.5f && !gameManager.GetRunning()) {
				gameManager.ChangeState ((int)State.Data.PushState);
			}
		}

		if (isAttacked) {
			if (listMonster.Count == 0)
				gameManager.ChangeState ((int)State.Data.EndState);
			else if (!gameManager.GetRunning()) {
				//print ("Attacked clear Push Start");
				gameManager.ChangeState ((int)State.Data.PushState);
			}
		}else if (timer > 1f) {
			//Time Over  -> fail State	
			if (!gameManager.GetRunning ()) {
				if (!gameManager.AttakedPlayer (listMonster [0].GetComponent<Monster> ().GetDamage ()))
					gameManager.ChangeState ((int)State.Data.EndState);
				else
					gameManager.ChangeState ((int)State.Data.FailState);
			}
		}
	}

	public override void Inputkey(char key){
		//공격키 한번만 입력 되게 하기 
		print("Button Clicked!!");
		if (!isAttacked && listMonster.Count>0) {
			
			GameObject tmp = listMonster [0]; //죽지않았경우 다시 넣기 위한 임시 저장 
			float lastPosX = listMonster [listMonster.Count - 1].transform.position.x; 

			//Attacked
			print("Monster Attacked!!!!!!!!!!!!!!!!!!!!");
			tmp.GetComponent<Monster> ().Attacked (lastPosX + 2, 0,gameManager.GetAttackDamage());
			listMonster.RemoveAt (0);

			//still Alive
			if (tmp.GetComponent<Monster> ().GetHP () > 0) {
				print ("Monster Still alive");
				listMonster.Add(tmp);
			}else {
				//Create New Monster
				print("Monster die and create monster");
				gameManager.CreateRemainMonster (lastPosX + 2,0);
			}



			isAttacked = true;
		}
	}
}