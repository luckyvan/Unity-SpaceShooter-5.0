using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
#region public field
	public GameObject hazard; // prefab used to generate asteroid

	public Vector3 spawnValue = new Vector3(6.5f, 0f, 15f);

	public int hazardCount = 10;

	public float spawnWait = 0.5f;

	public float startWait = 2f;

	public float waveWait = 2f;
#endregion

#region private field
	private Quaternion spawnRotation;
	
	public Vector3 spawnPosition = Vector3.zero;
#endregion

	IEnumerator spawnWaves(){
		yield return new WaitForSeconds(startWait);

		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				spawnPosition.x = Random.Range (-spawnValue.x, spawnValue.x);
				spawnPosition.z = spawnValue.z;
				spawnRotation = Quaternion.identity;
				
				Instantiate (hazard, spawnPosition, spawnRotation);	
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
	// Use this for initialization
	void Start () {
		StartCoroutine(spawnWaves ());
	}

}
