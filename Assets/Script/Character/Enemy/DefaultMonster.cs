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

	public void Start(){
		//temporary default init values
		speed = .1f;
		HP = 10;
		Armor = 5;
		AttackDamage = 10;
		inverseMoveTime = 1f / speed;
		rb2d = GetComponent<Rigidbody2D> ();
		isRun = false;
	}

	public override void Fail(){
		//print ("Fail Called "+isRun);
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (1.5f, 1.5f);
		Vector2 end2 = start + new Vector2 (2, 0);
		isRun = true;
		StartCoroutine (SmoothFail (end1, end2));
	}

	public override void Move(){
		//print ("Move Called "+isRun);
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (-2, 0);
		isRun = true;
		StartCoroutine (SmoothMovement (end));
	}

	public override void Attacked(float x ,float y){
		//print ("Attacked Called "+isRun);
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (10, 7);
		Vector3 end2 = start + new Vector2 (x, 0);
		isRun = true;
		StartCoroutine (SmoothAttacked (end1, end2));
	}

	protected IEnumerator SmoothAttacked (Vector3 end1, Vector3 end2){
		//print ("SmoothAttacked start");
		float sqrREmainingDistance = (transform.position - end1).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end1, inverseMoveTime * Time.deltaTime * 5);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end1).sqrMagnitude;
			yield return null;
		}

		//print ("SmoothAttacked x = " + end2.x+" y="+end2.y);
		if (end2.x < 11) {
			transform.position = new Vector3 (end2.x, end2.y, 0);
		} else {
			transform.position = new Vector3 (11, 0, 0);
		}

		isRun = false;
		print ("Attacked End x="+transform.position.x+" y="+transform.position.y);
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
		//print ("SmoothMovement start");
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
