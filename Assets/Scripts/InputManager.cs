using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class InputManager : MonoBehaviour {
	public static InputManager Instance {
		get;
		private set;
	}

	public delegate void BezelEvent(BezelDirection direction);
	public BezelEvent bezelEvent;

	[DllImport ("bezellib")]
	private static extern bool registerBezelListener (string gameObject, string methodName);

	void Awake () {
		if (Instance == null) {
			Instance = this;
		}
	}

	public void RegisterBezelListener (BezelEvent listener) {
		#if UNITY_TIZEN && !UNITY_EDITOR
		registerBezelListener (this.name, "BezelEventTrigger");
		bezelEvent = listener;
		#endif
	}

	public void BezelEventTrigger (string direction) {
		if (bezelEvent == null)
			return;
		
		if (direction.Equals ("CW")) {
			bezelEvent (BezelDirection.CLOCKWISE);
		} else {
			bezelEvent (BezelDirection.COUNTERCLOCKWISE);
		}
	}
}


