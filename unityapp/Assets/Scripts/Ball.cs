using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float vert = 1f, hori = 1f, speed = 1.5f;
	[SerializeField]
	private Rigidbody2D mBody;
	public bool started = false;

	// Use this for initialization
	void Start () {
		mBody = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		if (Input.GetMouseButtonUp (0)) {
			started = true;
		}
		if (!started)
			return;


		mBody.velocity = new Vector2 (hori, vert) * speed;
	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector2 normal = col.contacts [0].normal;
		//print (col.transform.name + " : " + Mathf.Abs(normal.x) + " : " + Mathf.Abs(normal.y) + " : " + (Mathf.Abs(normal.x) >= Mathf.Abs(normal.y)) );
		if (Mathf.Abs(normal.x) >= Mathf.Abs(normal.y)) {
			hori *= -1f;
		} else {
			vert *= -1f;
		}
		if (col.transform.tag == "Brick") {
			col.transform.SendMessage ("DestroyIt");
		}
		if (col.transform.tag == "Bar") {
			print (col.contacts [0].point.x + " : " + col.contacts [0].point.y);
			print (col.transform.position.x + " : " + col.transform.position.y);
			print ("D: " + (col.contacts [0].point.x - col.transform.position.x));
		}
	}


}
