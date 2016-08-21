using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(EdgeCollider2D))]
public class RoundCollider : MonoBehaviour {

	EdgeCollider2D col;

	public float radius = 3f;
	public int points = 4;
	public Vector2 center;

	void OnValidate () {
		SetCircleCollider ();
	}

	void Reset () {
		SetCircleCollider ();
	}

	private List<Vector2> newVerticies = new List<Vector2>();

	[ExecuteInEditMode]
	public void SetCircleCollider () {
		if (col == null) {
			col = GetComponent<EdgeCollider2D> ();
		}


		newVerticies.Clear ();

		col.points = new Vector2[points];
		float slice = 2 * Mathf.PI / (float)points;
		for (int i = 0; i < points; i++) {
			float angle = slice * i;
			float newX = (center.x + radius * Mathf.Cos(angle));
			float newY = (center.y + radius * Mathf.Sin(angle));

			Vector2 p = new Vector2(newX, newY);

			newVerticies.Add (p);
		}
		newVerticies.Add (newVerticies [0]);

		col.points = newVerticies.ToArray ();
	}

	void Start () {
		SetCircleCollider ();
	}
}
