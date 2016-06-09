using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject player;
	Vector3 position;
	Transform target;
	public float dampTime = 0.15f;
	public float cameraOffsetUpFromPlayer = 1;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<ScoreKeeper> ().GetAlive ())
		{
			Vector3 destination = new Vector3 (0, target.position.y + cameraOffsetUpFromPlayer, -300);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}/*
		if (player.GetComponent<ScoreKeeper> ().GetAlive ()) {
			position.Set (0, player.transform.position.y, -300);
			transform.position = position;
		}*/
		if (transform.position.y < 0) {
			position.Set (0, 0, -300);
			transform.position = position;
		}
	}
}
