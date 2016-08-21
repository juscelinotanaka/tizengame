using UnityEngine;
using System.Collections;

public class SkyboxController : MonoBehaviour {

	public float startY;
	void Start () {
		Input.gyro.enabled = true;
		startY = Input.gyro.gravity.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (Input.gyro.gravity.y - startY, Input.gyro.gravity.x));
	}
}
