using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HiScoreText : MonoBehaviour {

	public GameObject player;
	Text hiScore;

	// Use this for initialization
	void Start () {
		hiScore = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<ScoreKeeper> ().GetAlive ()) {
			hiScore.text = "Height Score: " + (int)player.GetComponent<ScoreKeeper> ().GetHiScore ();
		}	
	}
}
