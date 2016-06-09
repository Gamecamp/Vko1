using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {

	public GameObject[] windArray;
	public GameObject player;
	GameObject lastWind;
	Vector2 position;

	float minX;
	float maxX;

	float maxXdifference;

	public float leftEdgeOfCameraX;
	public float rightEdgeOfCameraX;

	float minY;
	float maxY;

	float nextX;
	int nextY;

	float[] yValues = new float[] { 5, 8, 12, 18, 22 };

	// Use this for initialization
	void Start () {
		minX = -30;
		maxX = 30;

		minY = 5;
		maxY = 10;

		lastWind = Instantiate (windArray [Random.Range (0, windArray.Length)], transform.position, Quaternion.identity) as GameObject;
	}

	// Update is called once per frame
	void Update () {

		if (player.transform.position.y + 30 > lastWind.transform.position.y) {

			position = DetermineNextPlatformLocation();
			lastWind = Instantiate (windArray [Random.Range (0, windArray.Length)], position, Quaternion.identity) as GameObject;

		}


	}

	public Vector2 DetermineNextPlatformLocation() {


		nextY = (int) Mathf.Abs(Random.Range(0, 5));

		//Debug.Log ("Y on : " + yValues[nextY]);

		nextX = DetermineNextPlatformX (yValues[nextY]);

		return new Vector2 (nextX, lastWind.transform.position.y + yValues[nextY]);

		//Debug.Log ("Y = " + yValues [nextY]);
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

		//Debug.Log ("Min X: " + minX + ", max X: " + maxX);

		return x;

	}
}
