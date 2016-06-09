using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y+40 < player.transform.position.y) {
			Kill ();
		}
	}

	public void Kill() {
		Destroy (gameObject);
	}
}
