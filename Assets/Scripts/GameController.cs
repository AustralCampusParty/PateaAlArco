using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {


	public static GameController instance;

	public Spawner spawner;

	public Text goalsMadeText;
	public Text goalsMissedText;
	public GameObject initialButtons;

	public float spawnBallTime;
	public int ballsToSpawn;

	private int goalsMade;
	private int goalsMissed;
	private bool gameEnded;
	private float currentTimer;
	private int ballsShooted;

	public GvrViewer viewer;

	private string golesString = "GOLES: ";
	private string erradosString = "ERRADOS: ";

	public GvrAudioSource goalSound;
	public GvrAudioSource missedSound;

	void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

	}

	// Use this for initialization
	void Start () {
		ResetGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameEnded) {
			currentTimer -= Time.deltaTime;
			if (currentTimer < 0) {
				goalSound.Stop ();
				missedSound.Stop ();
				spawner.SpawnBall ();
				ballsShooted--;
				currentTimer = spawnBallTime;
				Debug.Log (ballsShooted);
				if (ballsShooted == 0) {
					ResetGame ();
				}
			}
		}
	}

	public void Goal(GameObject ball){
		goalsMade++;
		goalsMadeText.text = golesString + goalsMade;
		goalSound.Play ();
	}

	public void GoalStopped(GameObject ball){
		goalsMissed++;
		goalsMissedText.text = erradosString + goalsMissed;
		missedSound.Play ();
	}

	public void StartGame(){
		gameEnded = false;
		goalsMissed = 0;
		goalsMade = 0;
		goalsMissedText.text = erradosString + goalsMissed;
		goalsMadeText.text = golesString + goalsMade;
		ballsShooted = ballsToSpawn;
		currentTimer = spawnBallTime;
		initialButtons.SetActive (false);
	}

	public void ResetGame(){
		gameEnded = true;
		initialButtons.SetActive (true);
	}

	public void RunAction(VRButton.ButtonAction action){
		switch (action) {
		case VRButton.ButtonAction.ChangeVRMode:
			viewer.VRModeEnabled = !viewer.VRModeEnabled; 
			break;
		case VRButton.ButtonAction.StartGame:
			StartGame ();
			break;
		default:
			break;
		}
	}
}
