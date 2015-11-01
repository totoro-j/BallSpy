using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class CameraControl : MonoBehaviour {
	public Camera Camera01;

	void Awake(){
		Application.targetFrameRate = 30;	
	}

	void Start(){
		switch (Application.loadedLevelName) {
		case "DemoTech":
			GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
			GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
			GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
			GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
			GameController.GetInstance().ViewerUpLine = 7.00f;//摄像机在观察者模式时的上极限
			GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
			GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
			GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
			break;
		case "Screen0101":
			GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
			GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
			GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
			GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
			GameController.GetInstance().ViewerUpLine = 7.00f;//摄像机在观察者模式时的上极限
			GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
			GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
			GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
			break;
		case "Screen0102":
			GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
			GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
			GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
			GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
			GameController.GetInstance().ViewerUpLine = 14.00f;//摄像机在观察者模式时的上极限
			GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
			GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
			GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
			break;
        case "Screen0103":
            GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
            GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
            GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
            GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
            GameController.GetInstance().ViewerUpLine = 14.00f;//摄像机在观察者模式时的上极限
            GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
            GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
            GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
            break;
        case "Screen0104":
            GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
            GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
            GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
            GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
            GameController.GetInstance().ViewerUpLine = 14.00f;//摄像机在观察者模式时的上极限
            GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
            GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
            GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
            break;
        case "Screen0105":
            GameController.GetInstance().CameraSizeFollowed = 7.1f;//摄像机跟随时的画面深度
            GameController.GetInstance().CameraSizeAll = 12.95f;//摄像机在观察者模式时的画面深度
            GameController.GetInstance().ViewerLeftLine = -27.43f;//摄像机在观察者模式时的左极限
            GameController.GetInstance().ViewerRightLine = 53.80f;//摄像机在观察者模式时的右极限
            GameController.GetInstance().ViewerUpLine = 14.00f;//摄像机在观察者模式时的上极限
            GameController.GetInstance().ViewerDownLine = 6.80f;//摄像机在观察者模式时的下极限
            GameController.GetInstance().FollowedLeftLine = -33.50f;//摄像机跟随时的左极限
            GameController.GetInstance().FollowedRightLine = 60.00f;//摄像机跟随时的右极限
            break;
		}
		Sequence CameraInitialization = new Sequence ();
		CameraInitialization.Prepend (HOTween.To (Camera01, 2, new TweenParms ().Prop ("orthographicSize", GameController.GetInstance().CameraSizeFollowed).Ease (EaseType.EaseOutQuart)));
		CameraInitialization.Insert (0, HOTween.To (Camera01.transform, 2, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().FollowedLeftLine, GameController.GetInstance().CurrentPlayer.transform.position[1], Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
		CameraInitialization.Play ();
		GameController.GetInstance().CameraInitializationState = true;
	}

	void Update(){
		if(GameController.GetInstance().CameraInitializationState == true){
			if(GameController.GetInstance().FilmMode == false){
				if (GameController.GetInstance().intoViewMode == true && GameController.GetInstance().isCameraFollowed == true) {
					GameController.GetInstance().isCameraFollowed = false;
					Sequence AllView = new Sequence ();
					AllView.Prepend (HOTween.To (Camera01, 1, new TweenParms ().Prop ("orthographicSize", GameController.GetInstance().CameraSizeAll).Ease (EaseType.EaseOutQuart)));
					if(GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().ViewerLeftLine){
						AllView.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().ViewerLeftLine+0.13f, 6.9f, Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().ViewerRightLine) {
						AllView.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().ViewerRightLine-1f, 6.9f, Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}else{
						AllView.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().CurrentPlayer.transform.position[0], 6.9f, Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}
					AllView.Play ();
				} else if(GameController.GetInstance().outViewMode == true && GameController.GetInstance().isCameraFollowed == false){
					GameController.GetInstance().isCameraFollowed = true;
					Sequence CameraInitialization = new Sequence ();
					CameraInitialization.Prepend (HOTween.To (Camera01, 1, new TweenParms ().Prop ("orthographicSize", GameController.GetInstance().CameraSizeFollowed).Ease (EaseType.EaseOutQuart)));
					if(GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().ViewerLeftLine){
						CameraInitialization.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().ViewerLeftLine+0.13f, GameController.GetInstance().CurrentPlayer.gameObject.transform.position[1], Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().ViewerRightLine) {
						CameraInitialization.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().ViewerRightLine-1f, GameController.GetInstance().CurrentPlayer.gameObject.transform.position[1], Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}else{
						CameraInitialization.Insert (0, HOTween.To (Camera01.transform, 1, new TweenParms ().Prop ("position", new Vector3(GameController.GetInstance().CurrentPlayer.gameObject.transform.position[0], GameController.GetInstance().CurrentPlayer.gameObject.transform.position[1], Camera01.transform.position[2])).Ease (EaseType.EaseOutQuart)));
					}
					CameraInitialization.Play ();
					GameController.GetInstance().isCameraFollowed = true;
				}
					
				if(GameController.GetInstance().isCameraFollowed == false){
					if(transform.position[0] > GameController.GetInstance().ViewerLeftLine && transform.position[0] < GameController.GetInstance().ViewerRightLine){
						transform.position = new Vector3(transform.position[0]-GameController.GetInstance().deltaMove[0]*0.02f,transform.position[1],-21.3f);
					}

					if(transform.position[1] < GameController.GetInstance().ViewerUpLine && transform.position[1] > GameController.GetInstance().ViewerDownLine){
						transform.position = new Vector3(transform.position[0],transform.position[1]-GameController.GetInstance().deltaMove[1]*0.02f,-21.3f);
					}

					if(transform.position[0] < GameController.GetInstance().ViewerLeftLine && GameController.GetInstance().deltaMove[0] < 0){
						print("Right");
						transform.position = new Vector3(transform.position[0]-GameController.GetInstance().deltaMove[0]*0.02f,transform.position[1],-21.3f);
					}

					if(transform.position[0] > GameController.GetInstance().ViewerRightLine && GameController.GetInstance().deltaMove[0] > 0){
						print("Left");
						transform.position = new Vector3(transform.position[0]-GameController.GetInstance().deltaMove[0]*0.02f,transform.position[1],-21.3f);
					}

					if(transform.position[1] < GameController.GetInstance().ViewerDownLine && GameController.GetInstance().deltaMove[1] < 0){
						print("Up");
						transform.position = new Vector3(transform.position[0],transform.position[1]-GameController.GetInstance().deltaMove[1]*0.02f,-21.3f);
					}

					if(transform.position[1] > GameController.GetInstance().ViewerUpLine && GameController.GetInstance().deltaMove[1] > 0){
						print("Down");
						transform.position = new Vector3(transform.position[0],transform.position[1]-GameController.GetInstance().deltaMove[1]*0.02f,-21.3f);
					}
				}
			}
			GameObject.Find("BG1").gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Camera01.velocity[0]/4,Camera01.velocity[1]/20,0);
			GameObject.Find("BG2").gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Camera01.velocity[0]/6,Camera01.velocity[1]/20,0);
		}
	}

	void LateUpdate(){
		if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().FilmMode == false) {
			if (GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().FollowedLeftLine && GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().FollowedRightLine) {
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer == GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot) {
					transform.position = new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.gameObject.transform.position [1], -21.3f);
				}
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer != GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot && GameController.GetInstance().IsRobot == true) {
					transform.position = new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f);
				}
			}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().FollowedLeftLine){
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer == GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot) {
					transform.position = new Vector3 (GameController.GetInstance().FollowedLeftLine, GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f);
				}
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer != GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot && GameController.GetInstance().IsRobot == true) {
					transform.position = new Vector3 (GameController.GetInstance().FollowedLeftLine, GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f);
				}
			}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().FollowedRightLine){
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer == GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot) {
					transform.position = new Vector3 (GameController.GetInstance().FollowedRightLine, GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f);
				}
				if (GameController.GetInstance().CameraInitializationState == true && GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().CurrentPlayer != GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot && GameController.GetInstance().IsRobot == true) {
					transform.position = new Vector3 (GameController.GetInstance().FollowedRightLine, GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f);
				}
			}
		}
	}
}