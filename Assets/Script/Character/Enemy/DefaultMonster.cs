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
	private bool isRun;

	public void Awake(){
		print ("Awake");
		speed = .2f;
		HP = 10;
		Armor = 5;
		AttackDamage = 10;
		inverseMoveTime = 1f / speed;
		rb2d = GetComponent<Rigidbody2D> ();
		isRun = false;
	}



	public void Init(){
		speed = .2f;
		HP = 10;
		Armor = 5;
		AttackDamage = 10;
		inverseMoveTime = 1f / speed;
		rb2d = GetComponent<Rigidbody2D> ();
		isRun = false;
	}

	public override int GetHP(){
		return HP;
	}

	public override int GetDamage(){
		return AttackDamage;
	}


		

	public override void Fail(){
		print ("Fail Called ");
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (1.5f, 1.5f);
		Vector2 end2 = start + new Vector2 (2, 0);
		isRun = true;
		StartCoroutine (SmoothFail (end1, end2));
	}

	public override void Move(){
		print ("Move Called ");
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (-2, 0);
		isRun = true;
		StartCoroutine (SmoothMovement (end));
	}

	public override void Attacked(float x ,float y,int damage){
		print ("Attacked Called ");
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (10, 7);
		Vector2 end2 = new Vector2 (x, 0);
		isRun = true;
		HP -= damage; //HP decrease
		StartCoroutine (SmoothAttacked (end1, end2));
	}

	protected IEnumerator SmoothAttacked (Vector3 end1, Vector3 end2){
		print ("SmoothAttacked start timescale="+Time.timeScale+" speed="+speed+" inverspeed="+inverseMoveTime);
		float sqrREmainingDistance = (transform.position - end1).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end1, inverseMoveTime * Time.deltaTime * 5);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end1).sqrMagnitude;
			yield return null;
		}
		if (HP > 0) {

			transform.position = new Vector3 (end2.x, end2.y, 0);
			isRun = false;
		} else {
			isRun = false;
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
		isRun = false;
		//print ("SmoothFail End");
	}

	protected IEnumerator SmoothMovement (Vector3 end){
		
		print ("SmoothMovement  monster start x="+end.x+" y="+end.y+" MoveTime="+inverseMoveTime+" speed="+speed);
		float sqrREmainingDistance = (transform.position - end).sqrMagnitude;
		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end, inverseMoveTime * Time.deltaTime);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		isRun = false;
		//print ("SmoothMovement End");
	}

	public override bool isRunning(){
		return isRun;
	}

	public override void Push ()
	{
	//	transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	public override void Attacked (char key)
	{
		
	}
}
