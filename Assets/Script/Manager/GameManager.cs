using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private Player player;
	private List<Monster> listMonster;

	private GameState gameState;
	private StartState startState;
	private PushState pushState;
	//private AttackState attackState;

	// Use this for initialization
	void Start () {
		//State Init
		StartState = new StartState ();
		StartState.Init(this);

		//Player Init
		//bring Saved Player Data
		player = new Player();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Push
}
