using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMonster : Monster {

	private int HP;
	private int Armor;
	private int AttackDamage;
	private Rigidbody2D rb2d;
	private float speed;

	private float inverseMoveTime;
	private GameManager gameManager;

	private List<char> Combokey;

	public void Awake(){
		print ("Create Monster");
		speed = .2f;
		HP = 10;
		Armor = 5;
		AttackDamage = 0;
		inverseMoveTime = 1f / speed;
		rb2d = GetComponent<Rigidbody2D> ();
		Combokey = new List<char> ();

		//default
		Combokey.Add ('A');
		Combokey.Add ('B');
	}

	public override void SetDefaultCombo(){
		print ("Clear Combo()");
		Combokey.Clear ();
		Combokey.Add ('A');
		Combokey.Add ('B');
		print ("Clear Combo End()");
	}

	public override void SetManager(GameManager gameManager){
		this.gameManager = gameManager;
	}
		

	public override int GetHP(){
		return HP;
	}

	public override int GetDamage(){
		return AttackDamage;
	}

	public override int InputKey(char x){
		print ("Press Key = " + x);
		print ("current Monster Combo Count=" + Combokey.Count);
		//Combo all clear
		if (Combokey.Count == 0)
			return 0;

		//correct Input Key
		if (Combokey [0] == x) {
			Combokey.RemoveAt (0);
			return Combokey.Count;
		} else{
			SetDefaultCombo(); // combo reset
			return -1; //incorrect Input key
		}

	}
		

	public override void Fail(){
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (1.5f, 1.5f);
		Vector2 end2 = start + new Vector2 (2, 0);
		gameManager.SetRunning (true);
		StartCoroutine (SmoothFail (end1, end2));
	}

	public override void Move(){
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (-2, 0);
		gameManager.SetRunning (true);
		StartCoroutine (SmoothMovement (end));
	}

	public override void Attacked(float x ,float y,int damage){
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (10, 7);
		Vector2 end2 = new Vector2 (x, 0);
		gameManager.SetRunning (true);
		HP -= damage; //HP decrease
		StartCoroutine (SmoothAttacked (end1, end2));
	}

	protected IEnumerator SmoothAttacked (Vector3 end1, Vector3 end2){
		//print ("SmoothAttacked start timescale="+Time.timeScale+" speed="+speed+" inverspeed="+inverseMoveTime);
		float sqrREmainingDistance = (transform.position - end1).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			//print ("SmoothAttacked timescale="+Time.timeScale+" speed="+speed+" inverspeed="+inverseMoveTime+" rb2d="+rb2d);
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end1, inverseMoveTime * Time.deltaTime * 5);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end1).sqrMagnitude;
			yield return null;
		}
		if (HP > 0) {

			transform.position = new Vector3 (end2.x, end2.y, 0);
			gameManager.SetAttackEnd (false);
			//set default combo
			SetDefaultCombo();
		} else {
			gameManager.SetAttackEnd (false);
			Destroy (gameObject);
		}
		//print ("Attacked End x="+transform.position.x+" y="+transform.position.y+" HP="+HP);
	}



	protected IEnumerator SmoothFail (Vector3 end,Vector3 end2){
		//print ("SmoothFail start");
		float sqrREmainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end, inverseMoveTime * Time.deltaTime *2);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}

		sqrREmainingDistance = (transform.position - end2).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end2, inverseMoveTime * Time.deltaTime * 2);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end2).sqrMagnitude;
			yield return null;
		}
		gameManager.SetRunning (false);
		//print ("SmoothFail End");
	}

	protected IEnumerator SmoothMovement (Vector3 end){
		
		//print ("SmoothMovement  monster MoveTime="+inverseMoveTime+" speed="+speed+" Time Scale="+Time.timeScale);
		float sqrREmainingDistance = (transform.position - end).sqrMagnitude;
		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end, inverseMoveTime * Time.deltaTime);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		gameManager.SetRunning (false);
		//print ("SmoothMovement End");
	}


	public override void Push ()
	{
	//	transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	public override void Attacked (char key)
	{
		
	}
}
