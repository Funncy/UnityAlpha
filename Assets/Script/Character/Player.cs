using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  : MonoBehaviour{

	int LV;
	int HP;
	int Armor;
	int AttackDamage_sword;
	int AttackDamage_bow;
	int AttackDamage_magic;
	int Exp;

	// Use this for initialization
	void Start () {
		//initilalize Character 
		LV = 1; //temporary values
		HP = 100;
		Armor = 10;
		AttackDamage_bow = 10;
		AttackDamage_magic = 10;
		AttackDamage_sword = 5;
		Exp = 0;
	}

	public void SetData(int LV, int HP, int Armor, int AttackDamage){
		this.LV = LV;
		this.HP = HP;
		this.Armor = Armor;
		this.AttackDamage_sword = AttackDamage;
	}

	public bool GetExp(int NextExp, int GetExp){
		Exp += GetExp;
		if (Exp >= NextExp) {
			Exp -= NextExp;
			LV++; //DB Update
			return true;
		}
		return false;
	}

	public int GetExp(){
		return Exp;
	}

	public int GetLV(){
		return LV;
	}

	public int GetHP(){
		return HP;
	}

	public int GetAttackDamage_sword(){
		return AttackDamage_sword;
	}

	public bool Attacked(int damage){
		HP -= damage;
		return HP > 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
