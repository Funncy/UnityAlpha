using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {

	public abstract void Push ();
	public abstract void Attacked(char key);
	public abstract void Move();
	public abstract bool isRunning ();

	public abstract void Fail();
	public abstract void Attacked(float x, float y, int damage);
	public abstract int GetHP();
}
