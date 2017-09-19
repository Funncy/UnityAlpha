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
		print("hi");
		speed = .1f;
		HP = 10;
		Armor = 5;
		AttackDamage = 10;
		inverseMoveTime = 1f / speed;
		rb2d = GetComponent<Rigidbody2D> ();
		isRun = false;
	}

	public override void Fail(){
		Vector2 start = transform.position;
		Vector2 end1 = start + new Vector2 (1.5f, 1.5f);
		Vector2 end2 = start + new Vector2 (2, 0);
		isRun = true;
		StartCoroutine (SmoothFail (end1, end2));
	}

	public override void Move(){
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (-2, 0);
		isRun = true;
		StartCoroutine (SmoothMovement (end));

	}

	protected IEnumerator SmoothFail (Vector3 end,Vector3 end2){
		float sqrREmainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end, inverseMoveTime * Time.deltaTime);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}

		sqrREmainingDistance = (transform.position - end2).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end2, inverseMoveTime * Time.deltaTime);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end2).sqrMagnitude;
			yield return null;
		}
		isRun = false;
	}

	protected IEnumerator SmoothMovement (Vector3 end){
		float sqrREmainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrREmainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2d.position, end, inverseMoveTime * Time.deltaTime);
			rb2d.MovePosition (newPosition);
			sqrREmainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
		isRun = false;
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
