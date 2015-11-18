using UnityEngine;
using System.Collections;

public class DoorOpenTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	//这个是教学关卡里的开门检测方法
	void OnTriggerEnter(Collider other){
		if(other.gameObject == GameController.GetInstance().CurrentPlayerTrigger && gameObject.name != "DoorOpener0301" && gameObject.name != "DoorOpenerPos2"){
			GameController.GetInstance().DoorOpener = gameObject.name;
			GameController.GetInstance().IsOnce = true;
			gameObject.SetActive(false);
		}else if(other.gameObject.name == "BallRobot02" && gameObject.name == "DoorOpener02"){
			GameController.GetInstance().AutoOpenDoor02 = true;
			GameController.GetInstance().IsOnce = true;
			gameObject.SetActive(false);
		}else if(other.gameObject.name == "Robot_a1-Body-2-SP" && gameObject.name == "DoorOpener03"){
			GameController.GetInstance().AutoOpenDoor03 = true;
			GameController.GetInstance().IsOnce = true;
			gameObject.SetActive(false);
		}else if(other.gameObject.name == "Robot_a1-Body-4-SP" && gameObject.name == "DoorOpener05"){
			GameController.GetInstance().AutoOpenDoor05 = true;
			GameController.GetInstance().IsOnce = true;
			gameObject.SetActive(false);
		}else if(other.gameObject.name == "BallRobot01" && gameObject.name == "DoorOpener0301"){
			other.gameObject.GetComponent<Rigidbody>().Sleep();
			gameObject.SetActive(false);
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "BallRobot" && gameObject.name == "DoorOpenerPos2") {
			Debug.LogWarning(other.gameObject.name);
			GameController.GetInstance().DoorOpener = gameObject.name;
			GameController.GetInstance ().IsOnce = true;
			gameObject.SetActive (false);
		}
	}
}
