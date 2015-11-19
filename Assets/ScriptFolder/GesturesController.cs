using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GesturesController : MonoBehaviour {
	public Camera Camera01;
	public Camera UICamera;
	private Dictionary<object,int[]> fingerList = new Dictionary<object,int[]>();

	void Start () {
		GameController.GetInstance().moveLeft = new int[1]{0};
		GameController.GetInstance().moveRight =new int[1]{0};
		GameController.GetInstance().moveUp =new int[1]{0};
		GameController.GetInstance().moveDown =new int[1]{0};
	}

	void OnSwipe(SwipeGesture gesture) {
		if (gesture.Direction == FingerGestures.SwipeDirection.Up && GameController.GetInstance().PlayerIsTriggered == true) {
			//上机器人
			GameController.GetInstance().intoRobot = true;
			StartCoroutine (intoRobotState (1f/Time.frameCount));
		} else if (gesture.Direction == FingerGestures.SwipeDirection.Up && GameController.GetInstance().IsRobot == true && GameController.GetInstance().intoRobot == false) {
			//开始工作
			GameController.GetInstance().intoWork = true;
			StartCoroutine (intoWorkState (1f/Time.frameCount));
		} else if (gesture.Direction == FingerGestures.SwipeDirection.Down && GameController.GetInstance().IsRobot == true) {
			if (GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork == true && GameController.GetInstance().intoWork == false) {
				//结束工作
				GameController.GetInstance().outWork = true;
				StartCoroutine (outWorkState (1f/Time.frameCount));
			}else if(GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork == false){
				//下机器人
				GameController.GetInstance().outRobot = true;
				StartCoroutine(outRobotState(1f/Time.frameCount));
			}
		}
	}

	IEnumerator intoRobotState(float second) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(second);
		GameController.GetInstance().intoRobot = false;
	}

	IEnumerator intoWorkState(float second) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(second); 
		GameController.GetInstance().intoWork = false;
	}

	IEnumerator outWorkState(float second) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(second); 
		GameController.GetInstance().outWork = false;
	}

	IEnumerator outRobotState(float second) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(second); 
		GameController.GetInstance().outRobot = false;
	}

	void OnFingerDown(FingerDownEvent e) {
		Ray ray1 = UICamera.GetComponent<Camera> ().ScreenPointToRay (e.Position);
		RaycastHit hit1;
		if(Physics.Raycast(ray1, out hit1)){
			if(hit1.transform.gameObject.CompareTag("UI")){
			}else{
				if (e.Position.x > 0 && e.Position.y < -e.Position.x + Screen.height && e.Position.y > e.Position.x) {
					//左屏幕
					if(!fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveLeft[0] = 1;
						fingerList.Add(e.Finger,GameController.GetInstance().moveLeft);
					}else if(fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveLeft[0] = 1;
						fingerList[e.Finger] = GameController.GetInstance().moveLeft;
					}
				}else if(e.Position.y > Screen.width - e.Position.x && e.Position.x < Screen.width && e.Position.y < e.Position.x + Screen.height - Screen.width){
					//右屏幕
					if(!fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveRight[0] = 1;
						fingerList.Add(e.Finger,GameController.GetInstance().moveRight);
					}else if(fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveRight[0] = 1;
						fingerList[e.Finger] = GameController.GetInstance().moveRight;
					}
				}else if(e.Position.y > Screen.height - e.Position.x && e.Position.y > Screen.height/2 && e.Position.y > e.Position.x + Screen.height - Screen.width && e.Position.y < Screen.height){
					//上屏幕
					if(!fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveUp[0] = 1;
						fingerList.Add(e.Finger,GameController.GetInstance().moveUp);
					}else if(fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveUp[0] = 1;
						fingerList[e.Finger] = GameController.GetInstance().moveUp;
					}
				}else if(e.Position.y > 0 && e.Position.y < e.Position.x && e.Position.y < Screen.height/2 && e.Position.y < Screen.width - e.Position.x){
					//下屏幕
					if(!fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveDown[0] = 1;
						fingerList.Add(e.Finger,GameController.GetInstance().moveDown);
					}else if(fingerList.ContainsKey(e.Finger)){
						GameController.GetInstance().moveDown[0] = 1;
						fingerList[e.Finger] = GameController.GetInstance().moveDown;
					}
				}
			}
		}

	}

	void OnFingerUp(FingerUpEvent e) {
		if(fingerList.ContainsKey(e.Finger)){
			//抬起手指
			fingerList[e.Finger][0] = 2;
		}
	}

	void OnDrag(DragGesture gesture){
		if(gesture.Phase == ContinuousGesturePhase.Updated){
			//拖动屏幕
			GameController.GetInstance().deltaMove =  gesture.DeltaMove;
		}
		if(gesture.Phase == ContinuousGesturePhase.Ended){
			//结束拖动屏幕，向量恢复为（0f,0f）
			GameController.GetInstance().deltaMove = new Vector2(0f,0f);
		}
	}
}
