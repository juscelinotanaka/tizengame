using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float vert = 1f, hori = 1f, speed = 1.5f;
	private Rigidbody2D mBody;
	public bool started = false;

	// Use this for initialization
	void Start () {
		mBody = GetComponent<Rigidbody2D> ();

	}
	
	void Update () {
		if (Input.GetMouseButtonUp (0) && !started) {
			started = true;
			mBody.velocity = new Vector2 ((transform.position.x >= 0 ? 1 : -1), 1) * speed;
		}

	}

	void OnCollisionEnter2D (Collision2D col) {
		Vector2 direction;
		Vector2 normal = col.contacts [0].normal;

		if (col.contacts.Length > 1) {
			print ("Mais : " + col.contacts.Length);
		}

		direction = Vector3.Reflect(col.relativeVelocity, normal ).normalized;

		// if hits bar change its direction according to the position it hitted on the bar
		if (col.transform.CompareTag("Bar")) {
			float diff = (col.contacts [0].point.x - col.transform.position.x);
			float tam = col.transform.localScale.x / 4;

			float percent = (diff / tam);
			float maxAngle = 5f;

			direction.x = maxAngle * percent;
			direction.y = maxAngle * (1 - percent);
		}

		mBody.velocity = direction.normalized * speed;

		// if hits a brick destroy it
		if (col.transform.tag == "Brick") {
			col.transform.SendMessage ("DestroyIt");
		} 
	}


}
