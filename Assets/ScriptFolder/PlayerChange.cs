using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class PlayerChange : MonoBehaviour {
	public GameObject BallRobot;//用于绑定小球
	public GameObject MissingBallPlayer;//用于绑定小球进入机器人的动画中白色小球的预设
	public string CurrentPlayerString;//获取当前操作对象的名字前缀
	public GameObject MissingBall;//用于初始化白色小球
	int start=1,length=7,WorkSpaceNum;//规定字符串截取的方法
	// 先确定好当前初始操作对象为小球
	void Awake () {
		GameController.GetInstance().CurrentPlayer = GameObject.Find("BallRobot");
		GameController.GetInstance().CurrentPlayerTrigger = GameObject.Find("BallRobot");
		foreach (Transform child in GameObject.Find("WorkSpace").transform) {
			GameController.GetInstance().WorkSpaceCollection.Add (child.gameObject);
		}
	}
	
	void FixedUpdate(){
		if (GameController.GetInstance().intoRobot == true && GameController.GetInstance().CurrentPlayer == BallRobot) {
			if( GameController.GetInstance().ObjectTriggerID.GetComponent<RobotGameOver>().isAvail == true && BallRobot.GetComponent<PlayerControl>().isAvail == true && GameController.GetInstance().BallToRobot == true && GameController.GetInstance().IsRobot == false){
				GameController.GetInstance().moveRight[0] = 0;
				GameController.GetInstance().moveLeft[0] = 0;
				//当前操作对象变更为小球接触到的有效机器人
				GameController.GetInstance().CurrentPlayer =  GameController.GetInstance().ObjectID;
				//被操作的机器人（玩家机器人）半透明状态还原
				GameController.GetInstance().ObjectID.gameObject.GetComponent<tk2dSprite>().color = new Color(1f, 1f, 1f, 1.0f);
				//当前操作对象变的触发更为小球接触到的有效机器人的触发
				GameController.GetInstance().CurrentPlayerTrigger =  GameController.GetInstance().ObjectTriggerID;
				CurrentPlayerString =  GameController.GetInstance().CurrentPlayer.name.Substring (start - 1, length);
				//小球不再接触到有效机器人
				GameController.GetInstance().PlayerIsTriggered = false;
				MissingBall = Instantiate(MissingBallPlayer, BallRobot.gameObject.transform.position,  Quaternion.identity) as GameObject;
				//小球被灭活，就消失了
				BallRobot.gameObject.SetActive(false);
				//摄像机位置调整
				Sequence BallAnim = new Sequence (new SequenceParms().OnComplete(ChangeRole));
				if(GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().FollowedLeftLine && GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().FollowedRightLine){
					BallAnim.Prepend(HOTween.To (GameObject.Find("Camera01").gameObject.transform, 0.3f,new TweenParms().Prop("position",new Vector3( GameController.GetInstance().CurrentPlayer.transform.position[0], GameController.GetInstance().CurrentPlayer.transform.position[1],-21.3f))));
				}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] < GameController.GetInstance().FollowedLeftLine){
					BallAnim.Prepend(HOTween.To (GameObject.Find("Camera01").gameObject.transform, 0.3f,new TweenParms().Prop("position",new Vector3( GameController.GetInstance().FollowedLeftLine, GameController.GetInstance().CurrentPlayer.transform.position[1],-21.3f))));
				}else if(GameController.GetInstance().CurrentPlayer.transform.position [0] > GameController.GetInstance().FollowedRightLine){
					BallAnim.Prepend(HOTween.To (GameObject.Find("Camera01").gameObject.transform, 0.3f,new TweenParms().Prop("position",new Vector3( GameController.GetInstance().FollowedRightLine, GameController.GetInstance().CurrentPlayer.transform.position[1],-21.3f))));
				}
				//小球附身时本体消失的动画
				BallAnim.Insert(0,HOTween.To (MissingBall.gameObject.transform, 0.15f,new TweenParms().Prop("localScale", new Vector3(0.1f,1.5f,1f))));
				BallAnim.Insert(0.1f,HOTween.To (MissingBall.gameObject.transform, 0.2f,new TweenParms().Prop("position", new Vector3(MissingBall.gameObject.transform.position[0],MissingBall.gameObject.transform.position[1]+2.3f,MissingBall.gameObject.transform.position[2]))));
				BallAnim.Insert(0.2f,HOTween.To (MissingBall.gameObject.GetComponent<tk2dSprite>(), 0.1f,new TweenParms().Prop("color", new Color(1,1,1,0))));
				BallAnim.Play();
			}
		}
	}

	void ChangeRole(){
		StartCoroutine(ChangeRolePermission());
		Destroy (MissingBall);
		//判断当前操作对象为机器人
		GameController.GetInstance().IsRobot = true;
		GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork = false;
		//有效机器人动画播放暂停
		GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator>().Play(CurrentPlayerString+"_Stop");
		//当前操作的机器人的工作状态为false；
		GameController.GetInstance().IsElevatored = false;
		if( GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().isWorkSpacePlay == true){
			GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().isWorkSpacePlay = false;
			GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().WorkSpaceControl();
		}
		//工作台动画状态调节
		for(WorkSpaceNum = 0; WorkSpaceNum < GameController.GetInstance().WorkSpaceCollection.Count; WorkSpaceNum++){
			if(CurrentPlayerString == GameController.GetInstance().WorkSpaceCollection[WorkSpaceNum].gameObject.name.Substring (start - 1, length) && GameController.GetInstance().WorkSpaceCollection[WorkSpaceNum].tag == "workspace"){
				GameController.GetInstance().WorkSpaceCollection[WorkSpaceNum].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
				GameController.GetInstance().WorkSpaceCollectionEx.Add(GameController.GetInstance().WorkSpaceCollection[WorkSpaceNum]);
			}
		}
	}

	IEnumerator ChangeRolePermission()  {
		yield return 0;
		GameController.GetInstance().BallToRobot = false;
	}
}
