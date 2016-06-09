using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	float yVelocity, xVelocity;
	public float maxYVelocity, maxXVelocity;
	public float jumpPower; 
	public float noMovementArea, slowMovementArea;

	float multiplier;

	Vector2 nextPosition;

	public int direction;

	Animator animator;

	int bubblegum;

	bool goingUp;
	float previousYValue;

	// Use this for initialization
	void Start () {
		yVelocity = 0;
		xVelocity = 0;
		direction = 1;
		bubblegum = 0;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		SetXVelocity ();
		UpdateMovement ();
		UpdateAnimation ();
	}

	void UpdateMovement() {
		transform.position = (Vector2)transform.position + (Vector2)GetVelocity ();
		transform.localScale = new Vector3 (direction, 1, 1);
	}

	void UpdateAnimation() {

		nextPosition = (Vector2)transform.position + GetVelocity ();

		if (transform.position.y < nextPosition.y) {
			animator.SetBool ("GoingUp", true);
			RotateDragon ();
		} else {
			animator.SetBool ("GoingUp", false);
			RotateDragon ();
		}
			
	}

	void RotateDragon() {
		
		if (animator.GetBool ("GoingUp")) {	

			multiplier = 1 - (GetVelocity ().y / maxYVelocity);

			transform.rotation = Quaternion.Euler (0, 0, (-30*direction) + multiplier * 80 * direction);
		} else {
			bubblegum = 0;

			multiplier = maxYVelocity - Mathf.Abs(GetVelocity ().y);

			//Debug.Log ("Multiplier: " + multiplier + ", Velocity = " + GetVelocity ().y);

			transform.rotation = Quaternion.Euler (0, 0, multiplier * -60 * direction);
		}
	}



	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "jump") {
			SetVelocity (new Vector2 (xVelocity, jumpPower));
		}

		col.GetComponent<SelfDestruct> ().Kill ();
	}

	float[] NoMovementArea(float x) {
		float[] coordinates = new float[2]{(float)x - noMovementArea / 2, (float)x + noMovementArea / 2};
		return coordinates;
	}

	float[] SlowMovementArea(float x) {
		float[] coordinates = new float[2]{ (float)x - slowMovementArea / 2, (float)x + slowMovementArea / 2 };
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


	}

	public void SetXVelocity() {
		float[] noMovement = NoMovementArea (MouseInputX ());
		float[] slowMovement = SlowMovementArea (MouseInputX ());
		float xPlayer = transform.position.x;

		if (xPlayer <= slowMovement [0]) {
			SetVelocity (new Vector2 (GetVelocity ().x + (slowMovement [0] - xPlayer) / 100, GetVelocity ().y));
		} else if (xPlayer >= slowMovement [1]) {
			SetVelocity (new Vector2 (GetVelocity ().x + (slowMovement [1] - xPlayer) / 100, GetVelocity ().y));
		} else if (xPlayer > slowMovement [0] && xPlayer < slowMovement [1]) {

			SetVelocity (new Vector2 (GetVelocity ().x / 3f, GetVelocity ().y));

			if (xPlayer <= noMovement [0]) {

				SetVelocity (new Vector2 (GetVelocity ().x + (noMovement [0] - xPlayer) / 1.1f, GetVelocity ().y));

			} else if (xPlayer >= noMovement [1]) {
				SetVelocity (new Vector2 (GetVelocity ().x + (noMovement [1] - xPlayer) / 1.1f, GetVelocity ().y));
			} else { 
				SetVelocity (new Vector2 (0, GetVelocity ().y));
			}
		}

		if (MouseInputX() < xPlayer) {
			direction = 1;
		} else {
			direction = -1;
		}
	}
}
