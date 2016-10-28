using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject shootingPosition;

	private FootballPool footballPool;


	// Use this for initialization
	void Start () {
		footballPool = GetComponent<FootballPool> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnBall(){
		for (int i = 0; i < spawnPoints.Length; i++) {
			spawnPoints[i].GetComponent<GvrAudioSource> ().Stop ();
		}



		GameObject startingObject = spawnPoints [Random.Range (0, spawnPoints.Length)];
		GameObject ball = footballPool.GetNextFootball (startingObject.transform.position);

		if (ball != null) {
			startingObject.GetComponent<GvrAudioSource> ().Play ();
			Vector3 shootDirection = (shootingPosition.transform.position - startingObject.transform.position).normalized;
			ball.GetComponent<Rigidbody> ().AddForce (shootDirection * 1200);
			ball.GetComponent<Ball> ().spawner = this;
		}

	}

	public void DestroyBall(GameObject ball){
		footballPool.DestroyFootball (ball);
	}
}
