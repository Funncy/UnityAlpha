using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float _speed = -0.1f;

	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {

		transform.Translate (_speed, 0, 0);

		if (transform.localPosition.x < -31.75f) {

			transform.localPosition = new Vector3 (48.25f, 0, 0);
		}
	}

}
