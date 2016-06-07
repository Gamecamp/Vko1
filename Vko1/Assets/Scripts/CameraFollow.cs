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

		position.Set(player.transform.position.x, player.transform.position.y, -30);

		transform.position = position;
	}
}
