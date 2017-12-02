using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Player player;

	public Text ComboStateText;
	public Text HpText;
	public Text LevelText;
	public Text ScoreText;

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
	private int ComboState;
	public static int Score;

	private GameObject monster;
	private bool isRunningMonster;
	private int RunningCount;

	private int NextExp = 100; // Fixed

	void Awake(){
		DontDestroyOnLoad (this); 
	}



	// Use this for initialization
	void Start () {

		//Player Init
		//bring Saved Player Data
		//player = new Player();
		Combo = 0;
		RunningCount = 0;
		isRunningMonster = false;
		Score = 0;



		//Get Character Data from DB
		//player.SetData();

		//Monster Get DB Random

		listMonster = new List<GameObject> ();

		//player = Instantiate (player, new Vector3 (-8.7f, -2f, 0), Quaternion.identity);
		//GameObject prefab = Resources.Load ("Prefab/Player") as GameObject;
		//prefab.transform.parent = this;


		//temporary monster create
		GameObject tmp;
		int ran;
		float m_height;
		for (int i = 0; i < 20; i += 2) {
			ran = (int)(Random.value * 10%3);
			print ("create Monseter ran = " + ran);
			if (ran == 0) {
				monster = Resources.Load ("Prefabs/Monster1") as GameObject;
				m_height = -2.04f;
			} else if (ran==  1) {
				monster = Resources.Load ("Prefabs/Monster2") as GameObject;
				m_height = -2.04f;
			} else {
				monster = Resources.Load ("Prefabs/Monster3") as GameObject;
				m_height = -1.54f;
			}
			m_height -= 0.2f;
			tmp = Instantiate (monster, new Vector3 (i, m_height, 0), Quaternion.identity);
			tmp.GetComponent<Monster> ().SetManager (this);
			tmp.GetComponent<Monster> ().SetDefaultData (ran);
			listMonster.Add (tmp);
		}

		MonsterQueueNum = 10;




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

	public void SetScore(int score){
		Score += score;
		ScoreText.text = "" + Score;
	}

	public void SetComboState(int state){
//		print (" Combostate = " + state);
		ComboState = state;
		switch (state) {
		case (int)State.Combo.Perfect:
			ComboStateText.text = "Perfect";
			break;
		case (int)State.Combo.Good:
			ComboStateText.text = "Good";
			break;
		case (int)State.Combo.Cool:
			ComboStateText.text = "Cool";
			break;
		}
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

		//Create Monster from DB

		if (MonsterQueueNum > 0) {
			MonsterQueueNum--;
			print ("Create Remain Monster X Y =" + x + " " + y);
			GameObject tmp;
			int ran;
			float m_height;
				ran = (int)(Random.value * 10%3);
				print ("create Monseter ran = " + ran);
				if (ran == 0) {
					monster = Resources.Load ("Prefabs/Monster1") as GameObject;
					m_height = -2.04f;
				} else if (ran==  1) {
					monster = Resources.Load ("Prefabs/Monster2") as GameObject;
					m_height = -2.04f;
				} else {
					monster = Resources.Load ("Prefabs/Monster3") as GameObject;
					m_height = -1.54f;
				}
				m_height -= 0.2f;
				tmp = Instantiate (monster, new Vector3 (x, m_height, 0), Quaternion.identity);
				tmp.GetComponent<Monster> ().SetManager (this);
				tmp.GetComponent<Monster> ().SetDefaultData (ran);
				listMonster.Add (tmp);


		}
	}

	public void GetExp(int exPoint){
		if (player.GetExp (NextExp, exPoint)) {
			//LV UP
			//DB Update Remain Point !!
			LevelText.text = "LV. "+player.GetLV();
		} 
	}

	public int GetScore(){
		return Score;
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
		if (player.Attacked (damage)) {
			HpText.text = "HP = " + player.GetHP ();
			return true;
		} else
			return false;
	}
	
	// Update is called once per frame
	void Update () {
		gameState.Update ();
		//print ("gameManager = " + listMonster [0].transform.position.x);
	}


}
