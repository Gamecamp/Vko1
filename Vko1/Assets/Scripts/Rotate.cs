using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public GameObject player;
	Animator animator;
	float multiplier;
	float maxVelocity;

	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
		multiplier = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetBool ("GoingUp")) {	
			
			multiplier = 1 - (player.GetComponent<PlayerMovement> ().GetVelocity ().y / player.GetComponent<PlayerMovement> ().maxYVelocity);

			//Debug.Log ("Multiplier: " + multiplier + ", Velocity = " + player.GetComponent<PlayerMovement> ().GetVelocity ().y);

			player.transform.rotation = Quaternion.Euler (0, 0, multiplier * 45 * player.GetComponent<PlayerMovement> ().direction);
		} else {
			multiplier = player.GetComponent<PlayerMovement> ().GetVelocity ().y / player.GetComponent<PlayerMovement> ().maxYVelocity;

			player.transform.rotation = Quaternion.Euler (0, 0, -33 * player.GetComponent<PlayerMovement> ().direction);
		}
	}
}
