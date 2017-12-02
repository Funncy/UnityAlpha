using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText.text = ""+GameManager.Score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
