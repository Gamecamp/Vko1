using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	Vector3 position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<ScoreKeeper> ().GetAlive ()) {
			position.Set (0, player.transform.position.y, -300);
			transform.position = position;
		}
	}
}
