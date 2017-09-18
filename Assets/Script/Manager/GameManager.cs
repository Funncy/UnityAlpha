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

		gameState = startState;

		//Player Init
		//bring Saved Player Data
		//player = new Player();

		Instantiate (player, new Vector3 (-8.7f, -1.7f, 0), Quaternion.identity);
		//GameObject prefab = Resources.Load ("Prefab/Player") as GameObject;
		//prefab.transform.parent = this;

		GameObject monster = Resources.Load ("Prefabs/Monster") as GameObject;
		//GameObject door = GameObject.Instantiate( Resources.Load("Assets/Prefabs/DefaultMonster.prefab", typeof(GameObject)) ) as GameObject;
		//GameObject instance = Instantiate(Resources.Load("Prefabs/DefaultMonster.prefab", typeof(GameObject))) as GameObject;
		print (monster);
		Instantiate (monster, new Vector3 (0, 0, 0), Quaternion.identity);


		//Monster create
		//listMonster = new List<Monster> ();


	}


	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
	}


}
