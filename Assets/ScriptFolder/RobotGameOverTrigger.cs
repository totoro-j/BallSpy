using UnityEngine;
using System.Collections;

public class RobotGameOverTrigger : MonoBehaviour {
	public GameObject IsGameOver;
	public bool isGuard_b = false;
	public bool isGuard_c = false;
	public bool IsTriggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay(Collider IsRobotWork){
		if(IsRobotWork.CompareTag("guard-1b")){
			IsTriggered = true;
			isGuard_b = true;
			IsGameOver = IsRobotWork.gameObject;
		}else if(IsRobotWork.CompareTag("guard-3")){
			IsTriggered = true;
			isGuard_c = true;
			IsGameOver = IsRobotWork.gameObject;
		}
	}

	void OnTriggerExit(Collider IsRobotWork){
		if (IsRobotWork.CompareTag ("guard-1b")) {
			IsTriggered = false;
			IsGameOver = null;
			isGuard_b = false;
		}else if(IsRobotWork.CompareTag("guard-3")){
			IsTriggered = false;
			IsGameOver = null;
			isGuard_c = false;
		}
	}
}
