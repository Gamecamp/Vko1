using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathText : MonoBehaviour {

	public GameObject player;
	Text death;

	// Use this for initialization
	void Start () {
		death = GetComponent<Text> ();
		death.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<ScoreKeeper> ().GetAlive ()) {
			death.enabled = true;
		}	
	}
}
