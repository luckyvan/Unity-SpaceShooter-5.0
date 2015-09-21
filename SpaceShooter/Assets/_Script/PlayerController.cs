using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rigidBody.velocity = movement * speed;
		rigidBody.position = new Vector3(
			Mathf.Clamp (rigidBody.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rigidBody.position.z, boundary.zMin, boundary.zMax));

		rigidBody.rotation = Quaternion.Euler (
			0.0f,
		    0.0f,
			rigidBody.velocity.x*(-tilt)
			);
	}
}
