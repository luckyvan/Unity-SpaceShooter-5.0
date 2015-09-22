using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	Rigidbody rigidBody;

	public float tumble = 10.0f;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		
		if (rigidBody != null) {
			rigidBody.angularVelocity = Random.insideUnitSphere * tumble;
		}else{
			throw new UnityException("No RigidBody Added to Player");
		}
	}

}
