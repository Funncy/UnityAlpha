using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState  :MonoBehaviour{

	public static int StartState = 1;
	public static int PushState = 2;
	public static int AttackState = 3;
	public static int FailState = 4;
	public static int EndState = 5;

	public abstract void Init (GameManager gameManager);
	public abstract void Update();
	public abstract void Inputkey(char key);
	public abstract void Restart();

}
