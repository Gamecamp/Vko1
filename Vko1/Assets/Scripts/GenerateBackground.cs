using UnityEngine;
using System.Collections;

public class GenerateBackground : MonoBehaviour {

	public float startingYPosition;
	float lastYPosition;

	float backgroundSpacing = 276;

	float backgroundSpawnHelper = 120;

	float xPosition = 0;
	float zPosition = 0;

	public GameObject player;
	public GameObject background;
	GameObject newBackground;



	// Use this for initialization
	void Start () {
		newBackground = Instantiate (background, new Vector3(xPosition, startingYPosition, zPosition), Quaternion.identity) as GameObject;
		lastYPosition = startingYPosition;
	}
	
	// Update is called once per frame
	void Update () {



		if (player.transform.position.y > lastYPosition + backgroundSpawnHelper) {

			newBackground = Instantiate (background, new Vector3(xPosition, lastYPosition+backgroundSpacing, zPosition), Quaternion.identity) as GameObject;
			lastYPosition = lastYPosition + backgroundSpacing;

		}
	}
}
