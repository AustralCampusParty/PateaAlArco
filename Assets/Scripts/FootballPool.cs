using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootballPool : MonoBehaviour {

	public GameObject football;

	private List<GameObject> pool = new List<GameObject>();
	private List<GameObject> activePool = new List<GameObject>();



	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			GameObject instance = GameObject.Instantiate (football, Vector3.one, Quaternion.identity) as GameObject;
			pool.Add(instance);
			instance.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject GetNextFootball(Vector3 startingPosition){
		if (pool.Count > 0) {
			GameObject objectToReturn = pool [0];
			pool.Remove (objectToReturn);
			activePool.Add (objectToReturn);
			objectToReturn.SetActive (true);

			objectToReturn.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			objectToReturn.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 0);
			objectToReturn.transform.position = startingPosition;
			return objectToReturn;
		}

		return null;
	}

	public void DestroyFootball(GameObject footballToDestroy){
		pool.Add (footballToDestroy);
		activePool.Remove (footballToDestroy);
		footballToDestroy.SetActive (false);


	}
}
