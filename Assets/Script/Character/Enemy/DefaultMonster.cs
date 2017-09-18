using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMonster : Monster {

	private int HP;
	private int Armor;
	private int AttackDamage;
	private Rigidbody2D rb2d;
	private float speed;

	public void Start(){
		//temporary default init values
		print("hi");
		speed = 5f;
		HP = 10;
		Armor = 5;
		AttackDamage = 10;
		//rb2d = GetComponent<Rigidbody2D> ();
	}

	public override void Push ()
	{
	//	transform.Translate (Vector3.left * speed * Time.deltaTime);
	}

	public override void Attacked (char key)
	{
		
	}
}
