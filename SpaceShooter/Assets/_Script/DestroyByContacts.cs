using UnityEngine;
using System.Collections;

public class DestroyByContacts : MonoBehaviour {

	public GameObject explosion;

	public GameObject playerExplosion;

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag != "Boundary") {
			Destroy (other.gameObject);
			Destroy (gameObject);	

			Instantiate (explosion, gameObject.transform.position, gameObject.transform.rotation);

			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.gameObject.transform.position, other.gameObject.transform.rotation);
			}
		}
	}
}
