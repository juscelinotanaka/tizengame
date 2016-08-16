using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Bar : MonoBehaviour {

	Vector3 position, lastPos;
	public Ball ball;
	public bool cheater = false;

	[DllImport ("bezellib")]
	private static extern bool tizenbezellib();

	[DllImport ("bezellib")]
	private static extern bool logMessage();

	// Use this for initialization
	void Start () {
		position = transform.position;
		lastPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		if (cheater) {
			transform.position = new Vector3 (ball.transform.position.x, transform.position.y);
		} else {
			if (Input.GetMouseButtonDown (0)) {
				lastPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			}
			if (Input.GetMouseButton (0)) {
				Vector3 actual = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Vector3 delta = actual - lastPos;
				position += delta;
				if (!ball.started) {
					ball.transform.position += new Vector3 (delta.x, 0f);
				}
				lastPos = actual;
				transform.position = new Vector3 (Mathf.Clamp (position.x, -4.5f, 4.5f), transform.position.y);
			}
			if (Input.GetButtonDown ("Cancel")) {
				//SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
				Debug.Log ("###-### : Value : " + tizenbezellib());
				Debug.Log ("###-### : Registering : " + logMessage());
			}
		}
	}
}
