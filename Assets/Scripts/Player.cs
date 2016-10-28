using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public static Player instance;


	public GameObject ball;
	public int speed;


	private bool ballIsShootable;

	void Awake(){
		if (instance == null) {
			instance = this;
			ballIsShootable = false;
		} else {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShootBall(Vector3 destination){
		if (ballIsShootable) {
			Vector3 shootDirection = (destination - ball.transform.position).normalized;


			ball.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
			ball.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 0);
			ball.GetComponent<Rigidbody> ().AddForce (shootDirection * speed);
			ball.GetComponent<Ball> ().Shooted = true;
		}

	}


	public bool BallIsShootable {
		get {
			return ballIsShootable;
		}
		set {
			ballIsShootable = value;
		}
	}
}
