using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButton : MonoBehaviour {

	public enum ButtonAction{StartGame, ChangeVRMode}


	private float timeGazed;
	private float timeGazedPercent;

	public Image filler;
	public float timeToLoad;

	private bool pointerEntered;

	public ButtonAction currentAction; 


	// Use this for initialization
	void Start () {
		timeGazed = 0;
		timeGazedPercent = 0;
		pointerEntered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerEntered) {
			timeGazed += Time.deltaTime;

			timeGazedPercent = timeGazed / timeToLoad;

			if (timeGazedPercent >= 1)
			{
				ResetButton ();
				GameController.instance.RunAction (currentAction);
			}
			else
			{
				filler.fillAmount = timeGazedPercent;
			}
		}
	}

	public void OnPointerEnter(BaseEventData data){
		pointerEntered = true;

	}

	public void OnPointerExit(BaseEventData data){
		ResetButton ();
	}

	private void ResetButton(){
		timeGazed = 0;
		timeGazedPercent = 0;
		pointerEntered = false;
		filler.fillAmount = timeGazedPercent;
	}
}
