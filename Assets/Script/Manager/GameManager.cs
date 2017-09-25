using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Player player;
	private List<GameObject> listMonster;

	private GameState gameState;
	private StartState startState;
	private PushState pushState;
	private AttackState attackState;
	private EndState endState;
	private FailState failState;

	//remain queue number
	private int MonsterQueueNum;

	private int Combo;

	private GameObject monster;
	private bool isRunningMonster;
	private int RunningCount;

	// Use this for initialization
	void Start () {

		//Player Init
		//bring Saved Player Data
		//player = new Player();
		Combo = 0;
		RunningCount = 0;
		isRunningMonster = false;

		listMonster = new List<GameObject> ();

		player = Instantiate (player, new Vector3 (-8.7f, -1.7f, 0), Quaternion.identity);
		//GameObject prefab = Resources.Load ("Prefab/Player") as GameObject;
		//prefab.transform.parent = this;


		//temporary monster create
		GameObject tmp;
		monster = Resources.Load ("Prefabs/Monster") as GameObject;
		for (int i = 0; i < 10; i += 2) {
			tmp = Instantiate (monster, new Vector3 (i, 0, 0), Quaternion.identity);
			tmp.GetComponent<Monster> ().SetManager (this);
			listMonster.Add (tmp);
		}

		MonsterQueueNum = 5;




		//State Init
		startState = new StartState ();
		startState.Init(this);
		pushState = new PushState ();
		pushState.Init (this);
		attackState = new AttackState ();
		attackState.Init (this);
		endState = new EndState ();
		endState.Init (this);
		failState = new FailState ();
		failState.Init (this);

		gameState = startState;

	}

	public void SetAttackEnd(bool running){
		isRunningMonster = running;
	}

	public void SetRunning(bool running){
		if (!running) {
			RunningCount += 1;
			if (RunningCount == listMonster.Count) {
				isRunningMonster = running;
				RunningCount = 0;
				return;
			}
		}
		else
		isRunningMonster = running;
	}

	public bool GetRunning(){
		return isRunningMonster;
	}

	public int GetCombo(){
		return Combo;
	}

	public void SetCombo(int combo){
		Combo = combo;
	}

	public int GetRemainMonsterNum(){
		return MonsterQueueNum;
	}

	public List<GameObject> getListMonster(){
		return listMonster;
	}
		
	public int GetAttackDamage(){
		return player.GetComponent<Player> ().GetAttackDamage_sword ();
	}

	public void CreateRemainMonster(float x, float y){
		if (MonsterQueueNum > 0) {
			MonsterQueueNum--;
			GameObject tmp;
			tmp = Instantiate (monster, new Vector3 (x, 0, 0), Quaternion.identity);
			tmp.GetComponent<Monster> ().SetManager (this);
			listMonster.Add (tmp);
			//print ("Create Complete");

		}
	}

	public void ChangeState(int state){
		switch (state) {

		case (int)State.Data.StartState:
			gameState = startState;
			break;
		case (int)State.Data.PushState:
			gameState = pushState;
			break;
		case (int)State.Data.AttackState:
			gameState = attackState;
			break;
		case (int)State.Data.FailState:
			gameState = failState;
			break;
		case (int)State.Data.EndState:
			gameState = endState;
			break;

		}
		gameState.Restart ();
	}

	public void PressButtonA(){
		gameState.Inputkey ('A');
	}

	public void PressButtonB(){	
		gameState.Inputkey ('B');
	}

	public void PressButtonC(){	
		gameState.Inputkey ('C');
	}

	public void PressButton(){
		gameState.Inputkey ('a');
	}

	public bool AttakedPlayer(int damage){
		return player.Attacked (damage);
	}
	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
		//print ("gameManager = " + listMonster [0].transform.position.x);
	}


}
