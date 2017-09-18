using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour {

	public abstract void Push ();
	public abstract void Attacked(char key);
}
