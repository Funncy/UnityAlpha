using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : GameState {

	private GameManager gameManager;

	private float timer;
	private List<GameObject> listMonster;

	private int isAttacked;
	private bool isCombo;

	public override void Init(GameManager gameManager){
		this.gameManager = gameManager;
		listMonster = gameManager.getListMonster ();
        Time.timeScale = 1f;
    }

	public override void Restart(){
		isAttacked = 1; // 1: default , 2:clear , 3:fail
		timer = 0;
		isCombo = false;
        Time.timeScale = 1f;
    }

	public override void Update () {
		//Time.timeScale = 1f;
		timer += Time.deltaTime;

		if (listMonster.Count == 0)
			gameManager.ChangeState ((int)State.Data.EndState);
		
		if (listMonster [0].transform.position.x > -5f && !gameManager.GetRunning()) {
			print ("listMonster 0 x > -1.5 ");
			if (timer > 0.5f ) {
				print ("listmonet pish");
				gameManager.ChangeState ((int)State.Data.PushState);
			}
		}

		if (isAttacked == 2) { // Success
            if (!isCombo) {
				if (timer <= 0.6f)
					gameManager.SetComboState ((int)State.Combo.Perfect);
				else if (timer <= 0.8f)
					gameManager.SetComboState ((int)State.Combo.Good);
				else
					gameManager.SetComboState ((int)State.Combo.Cool);
				isCombo = true;
			}


			if (listMonster.Count == 0)
				gameManager.ChangeState ((int)State.Data.EndState);
			else if (!gameManager.GetRunning ()) {


				
				gameManager.ChangeState ((int)State.Data.PushState);
			}
		} else if (isAttacked == 3 || timer > 1f) { //Fail
			//Time Over  -> fail State	
			if (!gameManager.GetRunning ()) {
				listMonster [0].GetComponent<Monster> ().SetDefaultCombo ();
				if (!gameManager.AttakedPlayer (listMonster [0].GetComponent<Monster> ().GetDamage ()))
					gameManager.ChangeState ((int)State.Data.EndState);
				else
					gameManager.ChangeState ((int)State.Data.FailState);
			}
		}
	}



	public void AttackEmeny(){

		if (listMonster.Count <= 0)
			return;
		//print ("attackEnemy");
		GameObject tmp = listMonster [0]; //죽지않았경우 다시 넣기 위한 임시 저장 
		float lastPosX = listMonster [listMonster.Count - 1].transform.position.x; 

		//Attacked
		tmp.GetComponent<Monster> ().Attacked (lastPosX + 2, -1.94f,gameManager.GetAttackDamage());
		listMonster.RemoveAt (0);

		//still Alive
		if (tmp.GetComponent<Monster> ().GetHP () > 0) {
			listMonster.Add(tmp);
		}else {
			//Create New Monster
			gameManager.CreateRemainMonster (lastPosX + 2,0);
		}

		//print ("Attack End");
	}

	public override void Inputkey(char key){
		int result;
		//print ("InputKey Clicked");

		if ( (isAttacked != 1) || (listMonster.Count <= 0) ){
			//print ("Can not Attack " + isAttacked + " co=" + listMonster.Count);
			return; //Already attack Enemy or clear Monster
		}
 
        result = listMonster [0].GetComponent<Monster> ().InputKey (key);
		print ("result = " + result);
		if (result == -1) {
			//Incorrect Input key
			isAttacked = 3;
		} else if (result == 0) {
            //Clear Combo 
            Time.timeScale = 2f;
            isAttacked = 2; 
			AttackEmeny ();
		}
			
	}
}