using UnityEngine;
using System.Collections;

public class BallPlayer : MonoBehaviour {
	public Rigidbody BallRigid;
	// Use this for initialization
	void Start () {
		BallRigid = GetComponent<Rigidbody> ();
		GameController.GetInstance().CurBallState = GameController.BallState.keepIdel;//默认保持静止
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch(GameController.GetInstance().CurBallState){
		case GameController.BallState.keepIdel://静止状态
			break;
		case GameController.BallState.move://普通运动状态
			BallRigid.useGravity = true;
			if (GameController.GetInstance().moveLeft[0] == 1) {
				BallRigid.AddForce (-GameController.GetInstance().MovePower, 0, 0);
			}
			if (GameController.GetInstance().moveRight[0] == 1) {
				BallRigid.AddForce (GameController.GetInstance().MovePower, 0, 0);
			}
			if (GameController.GetInstance().moveUp[0] == 1 && GameController.GetInstance().OnGround == true && GameController.GetInstance().JumpJudge == true && GameController.GetInstance().IsElevatored == false) {
				GameController.GetInstance().JumpJudge = false;
				BallRigid.velocity = new Vector3 (BallRigid.velocity[0], BallRigid.velocity[1]+GameController.GetInstance().JumpPower, BallRigid.velocity[2]);
			}
			//限制最大速度
			BallRigid.velocity = Vector3.ClampMagnitude (BallRigid.velocity, GameController.GetInstance().SpeedMax);
			break;
		case GameController.BallState.moveInElevator://电梯中运动状态
			BallRigid.useGravity = false;
			//BallRigid.Sleep ();
			//StartCoroutine (CheckMove());
			if (GameController.GetInstance().moveUp[0] == 1) {
				BallRigid.AddForce (0, GameController.GetInstance().MovePower, 0);
				//transform.position = new Vector3 (transform.position [0], transform.position [1] + 0.2f, transform.position [2]);
			}
			if (GameController.GetInstance().moveDown[0] == 1) {
				BallRigid.AddForce (0, -GameController.GetInstance().MovePower, 0);
				//transform.position = new Vector3 (transform.position [0], transform.position [1] - 0.2f, transform.position [2]);
			}
			if (GameController.GetInstance().moveRight[0] == 1) {
				BallRigid.AddForce (GameController.GetInstance().MovePower, 0, 0);
				//transform.position = new Vector3 (transform.position [0] + 0.2f, transform.position [1], transform.position [2]);
			}
			if (GameController.GetInstance().moveLeft[0] == 1) {
				BallRigid.AddForce (-GameController.GetInstance().MovePower, 0, 0);
				//transform.position = new Vector3 (transform.position [0] - 0.2f, transform.position [1], transform.position [2]);
			}
			//限制最大速度
			BallRigid.velocity = Vector3.ClampMagnitude (BallRigid.velocity, GameController.GetInstance().SpeedMax*2);
			break;	
		}
	}
	
	private IEnumerator CheckMove(){
		yield return null;
		if (BallRigid.IsSleeping ()) {
			BallRigid.WakeUp ();
		}
	}
}