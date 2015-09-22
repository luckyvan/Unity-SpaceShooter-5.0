using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {
	
	public float lifeTime = 2.0f;
	
	void Start(){

		Destroy (gameObject, lifeTime);

	}
}
