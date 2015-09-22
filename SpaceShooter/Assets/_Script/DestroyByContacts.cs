using UnityEngine;
using System.Collections;

public class DestroyByContacts : MonoBehaviour {
	
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag != "Boundary") {
			Destroy (other.gameObject);
			Destroy (gameObject);	
		}
	}
}
