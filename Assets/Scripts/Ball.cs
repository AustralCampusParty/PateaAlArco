using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Spawner spawner;
	public float timerToDestroy;

	private float currentTimer;

	private bool setToDestroy;
	private bool shooted;
	private bool collisioned;

	// Use this for initialization
	void Start () {
		InitBall ();
	}

	private void InitBall(){
		setToDestroy = false;
		currentTimer = timerToDestroy;
		shooted = false;
		collisioned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (setToDestroy) {
			currentTimer-= Time.deltaTime;
			if (currentTimer <= 0) {
				InitBall ();
				spawner.DestroyBall (gameObject);
			}
		}
	}

	void OnCollisionEnter(Collision c){
		if (!collisioned) {
			if (c.gameObject.CompareTag ("Red")) {
				GameController.instance.Goal (gameObject);
				setToDestroy = true;
				collisioned = true;
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 0);
			} else if (c.gameObject.CompareTag ("Arquero") || c.gameObject.CompareTag("Salida")) {
				GoalMissed ();
				collisioned = true;
				GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
				GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 0);
			}
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.name.Equals ("ShootingPosition")) {
			Player.instance.ball = gameObject;
			Player.instance.BallIsShootable = true;
		}

	}


	void OnTriggerExit(Collider c){
		if (c.name.Equals ("ShootingPosition")) {
			Player.instance.ball = gameObject;
			Player.instance.BallIsShootable = false;
			if (!shooted) {
				GoalMissed ();
			}
		}

	}

	public void GoalMissed(){
		GameController.instance.GoalStopped (gameObject);
		setToDestroy = true;
	}

	public bool Shooted {
		get {
			return shooted;
		}
		set {
			shooted = value;
		}
	}
}
