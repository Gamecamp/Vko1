using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public float leftXLimit;
	public float rightXLimit;
	public float speed;

	private float startTime;
	private float journeyLength;

	private bool goingRight;

	Vector2 leftPoint;
	Vector2 rightPoint;


	// Use this for initialization
	void Start () {

		leftPoint = new Vector2 (leftXLimit, transform.position.y);
		rightPoint = new Vector2 (rightXLimit, transform.position.y);

		startTime = Time.time;
		journeyLength = Vector2.Distance (new Vector2 (leftXLimit, transform.position.y), new Vector2 (rightXLimit, transform.position.y));

		if (Random.Range (0, 1) == 0) {
			goingRight = true;
		} else {
			goingRight = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (goingRight) {

			transform.localScale = new Vector3 (1, 1, 1);

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (leftPoint, rightPoint, fracJourney);

			if (transform.position.x >= rightXLimit) {
				goingRight = false;
				startTime = Time.time;
			}
		}

		if (!goingRight) {

			transform.localScale = new Vector3 (-1, 1, 1);

			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			transform.position = Vector3.Lerp (rightPoint, leftPoint, fracJourney);

			if (transform.position.x <= leftXLimit) {
				goingRight = true;
				startTime = Time.time;
			}
		}


	}
}
