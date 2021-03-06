﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
#region public field
	public GameObject hazard; // prefab used to generate asteroid

	public Vector3 spawnValue = new Vector3(6.5f, 0f, 15f);

	public int hazardCount = 10;

	public float spawnWait = 0.5f;

	public float startWait = 2f;

	public float waveWait = 2f;

	public Text scoreText;

	public Text gameOverText;

	public Text restartText;
#endregion

#region private field
	private Quaternion spawnRotation;
	
	public Vector3 spawnPosition = Vector3.zero;

	private int score;

	private bool gameOver;

	private bool restart;
#endregion

	IEnumerator spawnWaves(){
		yield return new WaitForSeconds(startWait);

		while (true) {
			if (gameOver) {
				break;
			}

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
		score = 0;

		UpdateScore ();

		gameOver = false;

		restart = false;

		gameOverText.text = "";

		restartText.text = "";

		StartCoroutine(spawnWaves ());
	}

	void Update (){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel(Application.loadedLevel);	
			}
		}
	}

	void UpdateScore (){
		scoreText.text = "得分：" + score;
	}


	public void AddScore (int scoreValue)
	{
		score += scoreValue;
		UpdateScore ();
	}

	public void GameOver ()
	{
		gameOver = true;

		restart = true;

		gameOverText.text = "游戏结束";

		restartText.text = "按R重新启动";
	}
}
