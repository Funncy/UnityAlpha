using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState  :MonoBehaviour{



	public abstract void Init (GameManager gameManager);
	public abstract void Update();
	public abstract void Inputkey(char key);
	public abstract void Restart();

}
