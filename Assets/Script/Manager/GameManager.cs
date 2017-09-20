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

	// Use this for initialization
	void Start () {

		//Player Init
		//bring Saved Player Data
		//player = new Player();

		listMonster = new List<GameObject> ();

		player = Instantiate (player, new Vector3 (-8.7f, -1.7f, 0), Quaternion.identity);
		//GameObject prefab = Resources.Load ("Prefab/Player") as GameObject;
		//prefab.transform.parent = this;


		//temporary monster create
		GameObject tmp;
		GameObject monster = Resources.Load ("Prefabs/Monster") as GameObject;
		for (int i = 0; i < 10; i += 2) {
			print ("create monster " + i);
			tmp = Instantiate (monster, new Vector3 (i, 0, 0), Quaternion.identity);
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
			print ("Create New Monster " + x + " " + y);
			GameObject tmp;
			GameObject monster = Resources.Load ("Prefabs/Monster") as GameObject;
			tmp = Instantiate (monster, new Vector3 (x, y, 0), Quaternion.identity);
			listMonster.Add (tmp);

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
		print("Stage Chnage "+state);
		gameState.Restart ();
	}

	public void PressButton(){
		gameState.Inputkey ('a');
	}

	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
		//print ("gameManager = " + listMonster [0].transform.position.x);
	}


}
