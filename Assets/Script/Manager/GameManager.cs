using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Player player;
	private List<GameObject> listMonster;

	private GameState gameState;
	private StartState startState;
	private PushState pushState;
	//private AttackState attackState;

	// Use this for initialization
	void Start () {
		//State Init
		startState = new StartState ();
		startState.Init(this);
		pushState = new PushState ();
		pushState.Init (this);

		gameState = startState;

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

		print ("monster = " + monster.transform.position.x);

		listMonster.Add (monster);

		//Monster create
		//listMonster = new List<Monster> ();


	}

	public List<GameObject> getListMonster(){
		return listMonster;
	}

	public void ChangeState(int state){
		switch (state) {
		case 1:
			break;
		case 2:
			gameState = pushState;
			gameState.Restart ();
			break;
		case 3:
			gameState = null;
			break;
		}
	}

	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
		print ("gameManager = " + listMonster [0].transform.position.x);
	}


}
