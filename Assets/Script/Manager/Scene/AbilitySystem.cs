using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySystem : MonoBehaviour {

	public Text attackPoint, defencePoint, healthPoint, remainPoint;
	private int attack, defence, health, remain;

	void Awake() {
		SetAbilityPoint ();
		GetAbilityPoint ();
	}

	public void SetAbilityPoint() {
		this.attack = 3;
		this.defence = 4;
		this.health = 5;
		this.remain = 2;
	}

	public void GetAbilityPoint() {
		attackPoint.text = "" + this.attack;
		defencePoint.text = "" + this.defence;
		healthPoint.text = "" + this.health;
		remainPoint.text = "" + this.remain;
	}

	public void SetAttackPoint(int delta) {
		// 공격력
		if ((delta < 0 && attack <= 1) || (delta > 0 && remain <= 0)) {
			return;
		}
		attack += delta;
		remain -= delta;
		this.GetAbilityPoint ();
	}

	public void SetDefencePoint(int delta) {
		// 방어력
		if ((delta < 0 && defence <= 1) || (delta > 0 && remain <= 0)) {
			return;
		}
		defence += delta;
		remain -= delta;
		this.GetAbilityPoint ();
	}

	public void SetHealthPoint(int delta) {
		// 체력
		if ((delta < 0 && health <= 1) || (delta > 0 && remain <= 0)) {
			return;
		}
		health += delta;
		remain -= delta;
		this.GetAbilityPoint ();
	}
}
