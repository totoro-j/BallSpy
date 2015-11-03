using UnityEngine;
using System.Collections;

public class RobotGameOverTrigger : MonoBehaviour {
	public GameObject IsGameOver;
	public bool IsTriggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay(Collider IsRobotWork){
		IsTriggered = true;
		IsGameOver = IsRobotWork.gameObject;
	}

	void OnTriggerExit(Collider IsRobotWork){
		IsTriggered = false;
	}
}
