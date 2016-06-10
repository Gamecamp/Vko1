using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	bool isGameOn;

	public GameObject player;

	// Use this for initialization
	void Start () {
		isGameOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<ScoreKeeper> ().GetAlive ())
			UDead ();
	}

	public void PlayButtonPressed() {
		if (player.GetComponent<ScoreKeeper> ().GetAlive ()) {
			isGameOn = true;
			gameObject.SetActive (false);
		} else {
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
	}

	public bool GetIsGameOn() {
		return isGameOn;
	}

	public void UDead() {
		gameObject.SetActive (true);
	}
}
