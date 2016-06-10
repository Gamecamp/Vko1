using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	bool isGameOn;

	// Use this for initialization
	void Start () {
		isGameOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayButtonPressed() {
		isGameOn = true;
		gameObject.SetActive(false);
	}

	public bool GetIsGameOn() {
		return isGameOn;
	}
}
