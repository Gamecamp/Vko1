using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float yVelocity;
	float xVelocity;
	public float maxYVelocity;
	public float jumpPower;
	Vector2 oldPosition;
	Vector2 newPosition;

	// Use this for initialization
	void Start () {
		yVelocity = 0;
		xVelocity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		oldPosition = transform.position;
		newPosition = oldPosition + GetVelocity ();
		transform.position = newPosition;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "jump") {
			SetVelocity (new Vector2 (0f, jumpPower));
		}
	}

	public Vector2 GetVelocity() {
		return new Vector2 (xVelocity, yVelocity);
	}

	public void SetVelocity(Vector2 velocity) {
		xVelocity = velocity.x;

		yVelocity = velocity.y;
	}
}
