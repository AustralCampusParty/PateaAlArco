using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class FieldLimit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(BaseEventData data){
		if (Player.instance) {
			PointerEventData ped = (PointerEventData)data;
			Vector3 targetPos = ped.pointerCurrentRaycast.worldPosition;
			Player.instance.ShootBall (targetPos);
		}
	}

}


