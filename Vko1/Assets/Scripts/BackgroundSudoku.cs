using UnityEngine;
using System.Collections;

public class BackgroundSudoku : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {

		if ((transform.position.y + 188.04f) < player.transform.position.y) {
			Kill ();
		}

	}

	void Kill() {
		Destroy (gameObject);
		Debug.Log ("Die die die!");
	}
}
