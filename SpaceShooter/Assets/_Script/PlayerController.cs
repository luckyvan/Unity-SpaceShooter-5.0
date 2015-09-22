using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody rigidBody;

	AudioSource audio;
#region public field
	[System.Serializable]
	public class Boundary{
		public float xMin, xMax, zMin, zMax;
	}

	public Boundary boundary;

	public float speed = 5.0f;

	public float tilt = 4.0f;

	public float fireRate = 0.5f;

	public GameObject shot;

	public Transform shotSpawn;


#endregion

#region private field
	private float nextFire = 0.0f;
#endregion
	void Start(){
		rigidBody = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();

		if (rigidBody == null) {
			throw new UnityException("No RigidBody Added to Player");
		}

		
		if (audio == null) {
			throw new UnityException("No Audio Source Added to Player");
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

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);

			audio.Play ();
		}
	}
}
