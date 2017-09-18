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

	// Use this for initialization
	public Player () {
		//initilalize Character 
		LV = 1; //temporary values
		HP = 100;
		Armor = 10;
		AttackDamage_bow = 10;
		AttackDamage_magic = 10;
		AttackDamage_sword = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
