using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private int bricks;
	private int destroyed;

	public static GameManager Instance {
		get;
		private set;
	}

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
	}

	public void PlayAgain () {
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
			
		}
	}
}
