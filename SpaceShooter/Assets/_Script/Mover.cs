using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	
	Rigidbody rigidBody;
	
	#region public field
	[System.Serializable]
	public class Boundary{
		public float xMin, xMax, zMin, zMax;
	}
	
	public Boundary boundary;
	
	public float speed = 5.0f;
	
	public float tilt = 4.0f;
	#endregion
	
	void Start(){
		rigidBody = GetComponent<Rigidbody>();
		
		if (rigidBody == null) {
			throw new UnityException("No RigidBody Added to Player");
		}

		Vector3 movement = new Vector3(0.0f, 0.0f, 1);
		rigidBody.velocity = movement * speed;

	}
}
