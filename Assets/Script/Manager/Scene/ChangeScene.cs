using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void SceneChangeToGame() {
		SceneManager.LoadScene ("GameScene");
		// test
	}

	public void SceneChangeToHome() {
		SceneManager.LoadScene ("HomeScene");
	}

	public void QuitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}
}
