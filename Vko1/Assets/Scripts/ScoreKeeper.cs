using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreKeeper : MonoBehaviour {

	public GameObject player;
	public GameObject playButton;
	public float fallLength;

	float height;

	bool alive;
	float hiScore, currentScore;

	float highestYvalue;
	float currentYvalue;

	List<float> scoreKeeper;

	float multiplier;
	float breakingPoint;
	int arrayIndexHelper;

	// Use this for initialization
	void Start () {
		alive = true;
		scoreKeeper = new List<float> ();
		multiplier = 1.0f;
		breakingPoint = 0;
		arrayIndexHelper = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		currentScore = (player.transform.position.y * multiplier) - breakingPoint;
		currentYvalue = player.transform.position.y;

		if (currentYvalue > highestYvalue) {
			highestYvalue = currentYvalue;
		}

		if (currentScore > hiScore)
			hiScore = currentScore;
		else if (currentYvalue < highestYvalue - fallLength) {
			alive = false;
			playButton.GetComponent<StartGame> ().UDead ();
		}
	}

	public bool GetAlive() {
		return alive;
	}

	public void AddToMultiplier() {
		multiplier = multiplier + 0.1f;
		scoreKeeper.Add (hiScore);
		breakingPoint = breakingPoint + hiScore;



		currentScore = 0;
		hiScore = 0;
	}


	public float GetHiScore() {

		float scoreAddedTogether = 0;
		if (scoreKeeper.Count != 0) {
			for (int i = 0; i < scoreKeeper.Count; i++) {
				scoreAddedTogether = scoreAddedTogether + scoreKeeper [i];
			}

			return scoreAddedTogether + hiScore;


		} else {
			return hiScore;
		}
	}

	public float GetMultiplier() {
		return multiplier;
	}
}
