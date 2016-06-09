using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public GameObject player;
	public float fallLength;
	bool alive;
	float hiScore, currentScore;

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		currentScore = player.transform.position.y;
		if (currentScore > hiScore)
			hiScore = currentScore;
		else if (currentScore < hiScore - fallLength)
			alive = false;
	}

	public bool GetAlive() {
		return alive;
	}

	public float GetHiScore() {
		return hiScore;
	}
}
