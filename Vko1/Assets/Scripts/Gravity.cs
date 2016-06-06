using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public float gravity;
	float yVelocity;
	float xVelocity;
	Vector2 velocity;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		velocity = GetComponent<PlayerMovement> ().GetVelocity();
		yVelocity = velocity.y - gravity;
		velocity = new Vector2 (velocity.x, yVelocity);

		GetComponent<PlayerMovement> ().SetVelocity (velocity);
	}
		
}
