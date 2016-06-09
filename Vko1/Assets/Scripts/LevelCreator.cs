using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {

	public GameObject wind;
	public GameObject bonusBalloon;

	public GameObject player;
	GameObject lastWind;

	Vector2 position;
	GameObject balloon;

	float minX;
	float maxX;

	float maxXdifference;

	public float leftEdgeOfCameraX;
	public float rightEdgeOfCameraX;

	public int balloonSpawnRate = 5;
	private int balloonHelper = 0;

	float nextX;
	int nextY;

	float[] yValues = new float[] { 5, 8, 12, 18, 22 };

	// Use this for initialization
	void Start () {
		minX = -30;
		maxX = 30;

		lastWind = Instantiate (wind, transform.position, Quaternion.identity) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		if (player.transform.position.y + 50 > lastWind.transform.position.y) {

			position = DetermineNextPlatformLocation ();
			lastWind = Instantiate (wind, position, Quaternion.identity) as GameObject;


			int rnd = Random.Range (0, balloonSpawnRate);

			if (rnd == 0) {
				balloonHelper++;
				if (balloonHelper == 4) {
					position = DetermineNextPlatformLocation ();
					balloon = Instantiate (bonusBalloon, position, Quaternion.identity) as GameObject;
					balloonHelper = 0;
				}

			}

		}




	}

	public Vector2 DetermineNextPlatformLocation() {


		nextY = (int) Mathf.Abs(Random.Range(0, 5));

		nextX = DetermineNextPlatformX (yValues[nextY]);

		return new Vector2 (nextX, lastWind.transform.position.y + yValues[nextY]);

	}

	float DetermineNextPlatformX(float y) {

		if (y == 18) {
			maxXdifference = 16;
		} else if (y == 10) {
			maxXdifference = 20;
		} else {
			maxXdifference = 24;
		}

		if (lastWind.transform.position.x - maxXdifference < leftEdgeOfCameraX)
			minX = leftEdgeOfCameraX;
		else
			minX = lastWind.transform.position.x - maxXdifference;
		
		if (lastWind.transform.position.x + maxXdifference > rightEdgeOfCameraX)
			maxX = rightEdgeOfCameraX;
		else
			maxX = lastWind.transform.position.x + maxXdifference;

		float x = Random.Range (minX, maxX);

		return x;

	}
}
