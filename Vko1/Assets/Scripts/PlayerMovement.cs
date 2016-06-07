using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float yVelocity, xVelocity;
	public float maxYVelocity, maxXVelocity;
	public float jumpPower, cursorWidth;
	Vector2 oldPosition, newPosition;
	int direction;

	// Use this for initialization
	void Start () {
		yVelocity = 0;
		xVelocity = 0;
		direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
		SetXVelocity ();
		oldPosition = transform.position;
		newPosition = oldPosition + GetVelocity ();
		transform.position = newPosition;
		transform.localScale = new Vector3 (direction, 1, 1);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "jump") {
			SetVelocity (new Vector2 (0f, jumpPower));
		}
	}

	float[] CursorWidthCoordinates(float x) {
		float[] coordinates = new float[2]{(float)x - cursorWidth/2, (float)x + cursorWidth/2};
		return coordinates;
	}

	float MouseInputX() {
		Vector3 v3Coordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float x = v3Coordinates.x;
		return x;
	}

	public Vector2 GetVelocity() {
		return new Vector2(xVelocity, yVelocity);
	}

	public void SetVelocity(Vector2 velocity) {
		if (Mathf.Abs (velocity.x) > maxXVelocity) {
			if (velocity.x < 0)
				xVelocity = -maxXVelocity;
			else
				xVelocity = maxXVelocity;
		}
		else xVelocity = velocity.x;
		if (Mathf.Abs (velocity.y) > maxYVelocity) {
			if (velocity.y < 0)
				yVelocity = -maxYVelocity;
			else 
				yVelocity = maxYVelocity;
		}
		else yVelocity = velocity.y;

		if (xVelocity < 0)
			direction = -1;
		else
			direction = 1;
	}

	public void SetXVelocity() {
		float[] xMouse = CursorWidthCoordinates (MouseInputX ());
		float xPlayer = transform.position.x;

		if (xPlayer <= xMouse [0]) {
			SetVelocity (new Vector2 (GetVelocity ().x + (xMouse [0] - xPlayer) / 100, GetVelocity ().y));
		} else if (xPlayer >= xMouse [1]) {
			SetVelocity (new Vector2 (GetVelocity ().x + (xMouse [1] - xPlayer) / 100, GetVelocity ().y));
		} else if (xPlayer > xMouse [0] && xPlayer < xMouse [1]) {
			SetVelocity (new Vector2 (0, GetVelocity ().y));
		}
	}
}
