using UnityEngine;
using System.Collections;

public class BallPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameController.GetInstance().CurBallState = GameController.BallState.keepIdel;//默认保持静止
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch(GameController.GetInstance().CurBallState){
		case GameController.BallState.keepIdel://静止状态
			break;
		case GameController.BallState.move://普通运动状态
			GetComponent<Rigidbody>().useGravity = true;
			if (GameController.GetInstance().moveLeft[0] == 1) {
				GetComponent<Rigidbody> ().AddForce (-GameController.GetInstance().MovePower, 0, 0);
			}
			if (GameController.GetInstance().moveRight[0] == 1) {
				GetComponent<Rigidbody> ().AddForce (GameController.GetInstance().MovePower, 0, 0);
			}
			if (GameController.GetInstance().moveUp[0] == 1 && GameController.GetInstance().OnGround == true && GameController.GetInstance().JumpJudge == true && GameController.GetInstance().IsElevatored == false) {
				GameController.GetInstance().JumpJudge = false;
				GetComponent<Rigidbody>().velocity = new Vector3 (GetComponent<Rigidbody>().velocity[0], GetComponent<Rigidbody>().velocity[1]+GameController.GetInstance().JumpPower, GetComponent<Rigidbody>().velocity[2]);
			}
			//限制最大速度
			GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude (GetComponent<Rigidbody>().velocity, GameController.GetInstance().SpeedMax);
			break;
		case GameController.BallState.moveInElevator://电梯中运动状态
			GetComponent<Rigidbody>().useGravity = false;
			GetComponent<Rigidbody>().Sleep ();
			StartCoroutine (CheckMove());
			if (GameController.GetInstance().moveUp[0] == 1) {
				transform.position = new Vector3 (transform.position [0], transform.position [1] + 0.2f, transform.position [2]);
			}
			if (GameController.GetInstance().moveDown[0] == 1) {
				transform.position = new Vector3 (transform.position [0], transform.position [1] - 0.2f, transform.position [2]);
			}
			if (GameController.GetInstance().moveRight[0] == 1) {
				transform.position = new Vector3 (transform.position [0] + 0.2f, transform.position [1], transform.position [2]);
			}
			if (GameController.GetInstance().moveLeft[0] == 1) {
				transform.position = new Vector3 (transform.position [0] - 0.2f, transform.position [1], transform.position [2]);
			}
				break;	
		}
	}
	
	private IEnumerator CheckMove(){
		yield return null;
		if (GetComponent<Rigidbody> ().IsSleeping ()) {
			GetComponent<Rigidbody> ().WakeUp ();
		}
	}
}