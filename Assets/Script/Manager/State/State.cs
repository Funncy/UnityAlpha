using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class State  {

	public enum Data : int
	{
		StartState = 1,
		PushState = 2,
		AttackState = 3,
		FailState = 4,
		EndState = 5
	}

	public enum Combo : int{
		Perfect = 1,
		Good = 2,
		Cool = 3
	}

}
