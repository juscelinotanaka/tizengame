using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float speed = 1.5f;
	private Rigidbody2D mBody;
	public bool started = false;

	// Use this for initialization
	void Start () {
		mBody = GetComponent<Rigidbody2D> ();

	}
	
	void Update () {
		if (Input.GetMouseButtonUp (0) && !started) {
			GameManager.Instance.StartGame ();
			started = true;
			mBody.velocity = new Vector2 ((transform.position.x >= 0 ? 1 : -1), 1) * speed;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.transform.tag == "DeathZone") {
			print ("Game Over");
			GameManager.Instance.GameOver ();
			GetComponent<Collider2D> ().enabled = false;
			return;
		}

		Vector2 direction;
		Vector2 normal = col.contacts [0].normal;

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

		//add some noise to avoid hitting back and forth at the same direction
		direction.x += Random.Range(0.001f, 0.005f);
		direction.y += Random.Range(0.001f, 0.005f);

		mBody.velocity = direction.normalized * speed;

		// if hits a brick destroy it
		if (col.transform.tag == "Brick") {
			col.transform.SendMessage ("DestroyIt");
		} 
	}


}
