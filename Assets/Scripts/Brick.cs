using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	void Start () {
		GameManager.Instance.AddBrick ();
	}

	public void DestroyIt () {
		GameManager.Instance.DestroyBrick ();
		Destroy (gameObject);
	}
}
