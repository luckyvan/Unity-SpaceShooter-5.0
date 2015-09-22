using UnityEngine;
using System.Collections;

public class DestroyByContacts : MonoBehaviour {

	public GameObject explosion;

	public GameObject playerExplosion;

	public int scoreValue = 10;

	private GameController gameController;

	void Start (){
		GameObject go = GameObject.FindWithTag ("GameController");

		if (go == null) {
			throw new UnityException ("No Game Object with Tag GameController");
		}

		gameController = go.GetComponent<GameController>();

		if (gameController == null) {
			throw new UnityException("No Game Controller");
		}
	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag != "Boundary") {
			Destroy (other.gameObject);
			Destroy (gameObject);	

			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);

			gameController.AddScore(scoreValue);
			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);

				gameController.GameOver();
			}
		}
	}
}
