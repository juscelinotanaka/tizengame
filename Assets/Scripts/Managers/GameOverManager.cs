using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {
	public Text destroyed, time, score; 


	public static GameOverManager Instance {
		get;
		private set;
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
		gameObject.SetActive (false);
	}

	public void GameOver() {
		gameObject.SetActive (true);
		destroyed.text = "Bricks Destroyed: " + GameManager.Instance.DestroyedBricks ();
		time.text = "Duration: " + GameManager.Instance.time.Elapsed.Minutes + "min " 
			+ GameManager.Instance.time.Elapsed.Seconds + "s";
		score.text = "SCORE: " + GameManager.Instance.Score ();
	}
}
