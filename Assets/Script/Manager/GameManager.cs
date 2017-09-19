using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Player player;
	private List<GameObject> listMonster;

	private GameState gameState;
	private StartState startState;
	private PushState pushState;
	private AttackState attackState;
	private EndState endState;
	private FailState failState;

	// Use this for initialization
	void Start () {

		//Player Init
		//bring Saved Player Data
		//player = new Player();

		listMonster = new List<GameObject> ();

		Instantiate (player, new Vector3 (-8.7f, -1.7f, 0), Quaternion.identity);
		//GameObject prefab = Resources.Load ("Prefab/Player") as GameObject;
		//prefab.transform.parent = this;



		GameObject monster = Resources.Load ("Prefabs/Monster") as GameObject;
		monster = Instantiate (monster, new Vector3 (0, 0, 0), Quaternion.identity);
		listMonster.Add (monster);

		 monster = Resources.Load ("Prefabs/Monster") as GameObject;
		monster = Instantiate (monster, new Vector3 (2, 0, 0), Quaternion.identity);

		//print ("monster = " + monster.transform.position.x);

		listMonster.Add (monster);

		//Monster create
		//listMonster = new List<Monster> ();



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

	public List<GameObject> getListMonster(){
		return listMonster;
	}

	public void ChangeState(int state){
		print("chnageState ="+state);
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

	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
		//print ("gameManager = " + listMonster [0].transform.position.x);
	}


}
