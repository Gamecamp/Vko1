using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {

	public GameObject[] windArray;
	public GameObject player;
	GameObject lastWind;
	Vector2 position;

	public float minX;
	public float maxX;

	float lastX;
	float maxXDifference;

	float nextX;
	float nextY;

	float helper = 0;

	// Use this for initialization
	void Start () {
		lastWind = Instantiate (windArray [Random.Range (0, windArray.Length)], transform.position, Quaternion.identity) as GameObject;
	}

	// Update is called once per frame
	void Update () {

		if (player.transform.position.y + 30 > lastWind.transform.position.y) {

			helper++;
			position = DetermineNextPlatformX();
			lastWind = Instantiate (windArray [Random.Range (0, windArray.Length)], position, Quaternion.identity) as GameObject;

		}


	}

	public Vector2 DetermineNextPlatformX() {

		nextX = Random.Range (minX, maxX);

		nextY = lastWind.transform.position.y + 3;

		lastX = nextX;

		return new Vector2 (nextX, nextY);
	}
}
