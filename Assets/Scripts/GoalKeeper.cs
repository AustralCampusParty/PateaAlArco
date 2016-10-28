using UnityEngine;
using System.Collections;

public class GoalKeeper : MonoBehaviour {

	public GameObject rightLimit;
	public GameObject leftLimit;

	public float goalKeeperSpeed;

	private bool moveToRight;

	// Use this for initialization
	void Start () {
		moveToRight = Random.Range(0,1f)<0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (moveToRight) {
			transform.Translate (-Vector2.right * goalKeeperSpeed * Time.deltaTime);
		} else {
			transform.Translate (Vector2.right * goalKeeperSpeed * Time.deltaTime);
		}

		if (transform.position.x >= rightLimit.transform.position.x) {
			moveToRight = false;
		}

		if (transform.position.x <= leftLimit.transform.position.x) {
			moveToRight = true;
		}
	}
}
