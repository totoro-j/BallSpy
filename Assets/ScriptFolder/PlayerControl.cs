using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class PlayerControl : MonoBehaviour {
	public bool isAvail = true;//判断小球是否可操作

	void FixedUpdate(){
		//如果摄像机的初始化动画播放完成
		if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().FilmMode == false) {
			if (GameController.GetInstance().isCameraFollowed == true) {
				if (isAvail == true) {
					if (GameController.GetInstance().IsElevatored == false) {
						//小球普通运动状态
						GameController.GetInstance().CurBallState = GameController.BallState.move;
					} else {
						//小球电梯中运动状态
						GameController.GetInstance().CurBallState = GameController.BallState.moveInElevator;
					}
				}
			}else{
				//小球静止状态
				GameController.GetInstance().CurBallState = GameController.BallState.keepIdel;
			}
		}else if(GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().FilmMode == true){
			//小球静止状态
			GameController.GetInstance().CurBallState = GameController.BallState.keepIdel;
		}	
	}	
}
