using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Bar : MonoBehaviour {

	Vector3 position, lastPos;
	public Ball ball;
	public bool cheater = false;

	public float minMaxX = 3.48f;
	public float bezelVariation = 0.25f;

	// Use this for initialization
	void Start () {
		position = transform.position;
		InputManager.Instance.RegisterBezelListener (BezelMoved);
		Application.runInBackground = true;
	}

	void BezelMoved (BezelDirection dir) {
		if (dir == BezelDirection.CLOCKWISE) {
			Move (new Vector2 (-bezelVariation, 0f));
		} else {
			Move (new Vector2 (bezelVariation, 0f));
		}
	}

	private void Move (Vector3 delta) {
		position += delta;
		if (!ball.started) {
			ball.transform.position += new Vector3 (delta.x, 0f);
		}
		transform.position = new Vector3 (Mathf.Clamp (position.x, -minMaxX, minMaxX), transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (cheater) {
			transform.position = new Vector3 (ball.transform.position.x + Random.Range(0.11f, 0.25f), transform.position.y);
			if (Input.GetKey (KeyCode.U)) {
				Time.timeScale = 1f;
			} else if (Input.GetKey (KeyCode.I)) {
				Time.timeScale = 2f;
			} else if (Input.GetKey (KeyCode.O)) {
				Time.timeScale = 3f;
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				lastPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			if (Input.GetMouseButton (0)) {
				Vector3 actual = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 delta = actual - lastPos;
				Move (delta);
				lastPos = actual;

			}
			if (Input.GetButtonDown ("Cancel")) {
				#if !UNITY_EDITOR
				Application.Quit ();
				#endif
			}
		}
	}


}
