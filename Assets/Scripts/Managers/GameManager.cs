using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private int bricks;
	private int destroyed;

	public Stopwatch time = new Stopwatch();

	public static GameManager Instance {
		get;
		private set;
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
	}

	public int DestroyedBricks () {
		return destroyed;
	}

	public int Score () {
		return Mathf.Clamp(destroyed * 50 - (int)time.ElapsedMilliseconds / 1000, 0, int.MaxValue);
	}

	public void StartGame () {
		time.Start ();
	}

	public void PlayAgain () {
		Time.timeScale = 1f;
		time.Reset ();
		bricks = 0;
		destroyed = 0;
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void AddBrick() {
		bricks++;
	}

	public void DestroyBrick () {
		destroyed++;
		if (bricks - destroyed == 0) {
			GameOver ();
		}
	}

	public void GameOver () {
		Time.timeScale = 0f;
		time.Stop ();
		GameOverManager.Instance.GameOver ();
	}
}
