using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Collections.Generic;

public class PlayerTrigger : MonoBehaviour {
	int num = 0;//计数器，用于小球同时遇到多个机器人时，只选择一个机器人进行附身和触发
	int i;

	void Awake(){
		InvokeRepeating("ChangeFace", 5, Random.Range(2.0f,5.0f));//用于生成小球表情变化的时间随机
	}

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter(Collider other){
		//用于触发小球跑到终点时候的场景切换
		if(other.name == "WinTag"){
			if(Global.GetInstance ().CurrentStayLevel == GameController.GetInstance ().CurrentLevelNum){
				for(i=0;i < GameController.GetInstance().Levels.Count; i++){
					if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && (GameController.GetInstance ().TimeRecorder < GameController.GetInstance().Levels[i].LevelTime || GameController.GetInstance().Levels[i].LevelTime == 0)){
						GameController.GetInstance().Levels[i].LevelTime = GameController.GetInstance ().TimeRecorder;
						Global.GetInstance().CurrentLevelTime = GameController.GetInstance ().TimeRecorder;
					}else if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && (GameController.GetInstance ().TimeRecorder >= GameController.GetInstance().Levels[i].LevelTime && GameController.GetInstance().Levels[i].LevelTime != 0)){
						Global.GetInstance().CurrentLevelTime = GameController.GetInstance().Levels[i].LevelTime;
					}
				}
				GameController.GetInstance ().CurrentLevelNum = GameController.GetInstance ().CurrentLevelNum + 1;
				GameController.GetInstance ().CurrentLevelSceneNum = GameController.GetInstance ().CurrentLevelNum % 5;
				if(GameController.GetInstance ().CurrentLevelSceneNum == 0){
					GameController.GetInstance ().CurrentLevelSceneNum = 5;
				}
				GameController.GetInstance().Levels.Add(
					new Level{
					LevelNum = GameController.GetInstance ().CurrentLevelNum,
					LevelScene = (GameController.GetInstance ().CurrentLevelNum - GameController.GetInstance ().CurrentLevelSceneNum %5)/5 + 1,
					LevelSceneNum = GameController.GetInstance ().CurrentLevelSceneNum,
					LevelLock = false,
					isCurrent = true,
					LevelTime = 0,
					LevelStars = 0
				}
				);
				if(Global.GetInstance().SelectedSave == 1 && ES2.Exists ("player01.dat")){
					ES2.Save(GameController.GetInstance ().CurrentLevelNum, "player01.dat?tag=CurrentLevelNum");
					ES2.Save(1, "player01.dat?tag=CurrentLevelScene");
					ES2.Save(GameController.GetInstance ().CurrentLevelSceneNum, "player01.dat?tag=CurrentLevelSceneNum");
				}else if(Global.GetInstance().SelectedSave == 2 && ES2.Exists ("player02.dat")){
					ES2.Save(GameController.GetInstance ().CurrentLevelNum, "player02.dat?tag=CurrentLevelNum");
					ES2.Save(1, "player02.dat?tag=CurrentLevelScene");
					ES2.Save(GameController.GetInstance ().CurrentLevelSceneNum, "player02.dat?tag=CurrentLevelSceneNum");
				}else if(Global.GetInstance().SelectedSave == 3 && ES2.Exists ("player03.dat")){
					ES2.Save(GameController.GetInstance ().CurrentLevelNum, "player03.dat?tag=CurrentLevelNum");
					ES2.Save(1, "player03.dat?tag=CurrentLevelScene");
					ES2.Save(GameController.GetInstance ().CurrentLevelSceneNum, "player03.dat?tag=CurrentLevelSceneNum");
				}
				for(i=0;i < GameController.GetInstance().Levels.Count; i++){
					if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && GameController.GetInstance().Levels[i].isCurrent == true){
						GameController.GetInstance().Levels[i].isCurrent = false;
					}
				}
				Global.GetInstance().CurrentLevelTime = GameController.GetInstance ().TimeRecorder;
			}else{
				for(i=0;i < GameController.GetInstance().Levels.Count; i++){
					if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && (GameController.GetInstance ().TimeRecorder < GameController.GetInstance().Levels[i].LevelTime || GameController.GetInstance().Levels[i].LevelTime == 0)){
						GameController.GetInstance().Levels[i].LevelTime = GameController.GetInstance ().TimeRecorder;
						Global.GetInstance().CurrentLevelTime = GameController.GetInstance ().TimeRecorder;
					}else if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && (GameController.GetInstance ().TimeRecorder >= GameController.GetInstance().Levels[i].LevelTime && GameController.GetInstance().Levels[i].LevelTime != 0)){
						Global.GetInstance().CurrentLevelTime = GameController.GetInstance().Levels[i].LevelTime;
					}
				}
			}
			if(Global.GetInstance().SelectedSave == 1 && ES2.Exists ("player01.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player01.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 2 && ES2.Exists ("player02.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player02.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 3 && ES2.Exists ("player03.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player03.dat?tag=LevelInfo");
			}
			TweenParms GameWin = new TweenParms ();
			//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
			GameWin.Prop ("color", new Color (1, 1, 1, 1));
			//回调函数GameOverScene
			GameWin.OnComplete (GameWinScene);
			HOTween.To (GameObject.Find ("over").gameObject.GetComponent<tk2dSprite> (), 0.5f, GameWin);
		}
		//用于检测小球触发到机器人时，将num检测值重置
		if (other.CompareTag("RobotTrigger") && other.GetComponent<RobotGameOver> ().isAvail == true) {
			num = 0;
		}
	}
	
	private void GameWinScene(){
		Application.LoadLevel ("DemoWin");
	}
	
	void OnCollisionStay(Collision Ground){
		//检测与地面的碰撞
		if (Ground.gameObject.CompareTag("ground")) {
			//为了防止小球在天花板上滚动，检测碰撞法线是否向上
			if(Ground.contacts[0].normal[1] > 0){
				GameController.GetInstance().OnGround = true;
			}
		}
	}
	
	void OnCollisionExit(Collision Ground){
		//检测小球是否离开地面（主要是小球跳起来了）
		if (Ground.gameObject.CompareTag("ground")) {
			GameController.GetInstance().JumpJudge = true;
			GameController.GetInstance().OnGround = false;
		}
	}
	
	void OnTriggerStay(Collider NextPlayer){
		//如果触发器为机器人且机器人有效(漏洞是在机器人身边等他失效的话没有判断值可以判断此变化，所以在PlayerChange里继续对机器人有效性进行检测)
		if(NextPlayer.CompareTag("RobotTrigger") && NextPlayer.GetComponent<RobotGameOver>().isAvail == true) {
			num++;
			//只选择num为1时的机器人作为触发机器人
			if(num == 1){
				//小球接触有效机器人状态为true；
				GameController.GetInstance().PlayerIsTriggered = true;
				//获取小球接触到的有效机器人的触发
				GameController.GetInstance().ObjectTriggerID = NextPlayer.gameObject;
				//获取小球接触到的有效机器人
				GameController.GetInstance().ObjectID = NextPlayer.gameObject.transform.parent.gameObject;
				//机器人变成半透明状态
				GameController.GetInstance().ObjectID.gameObject.GetComponent<tk2dSprite>().color = new Color(1f, 1f, 1f, 0.5f);
			}
		}
		
		if(NextPlayer.CompareTag("elevator")) {
			//触发中，电梯判断为true；
			GameController.GetInstance().IsElevatored = true;
		}
	}
	
	void OnTriggerExit(Collider NextPlayer){
		//如果触发器为机器人
		if (NextPlayer.CompareTag("RobotTrigger")) {
			//将num值重置
			num = 0;
			//如果机器人有效
			if(NextPlayer.GetComponent<RobotGameOver>().isAvail == true){
				//小球接触有效机器人状态为false;
				GameController.GetInstance().PlayerIsTriggered = false;
				//机器人颜色还原；
				NextPlayer.gameObject.transform.parent.gameObject.GetComponent<tk2dSprite> ().color = new Color (1f, 1f, 1f, 1.0f);
			}else{
				GameController.GetInstance().PlayerIsTriggered = false;
			}		
		}
		
		if(NextPlayer.CompareTag("elevator")) {
			//触发中，电梯判断为true；
			GameController.GetInstance().IsElevatored = false;
		}
	}
	
	void ChangeFace(){
		int FaceType = Random.Range(0,10);
		switch (FaceType) {
		case 0:
			GetComponent<tk2dSprite>().SetSprite("兴奋");
			break;
		case 1:
			GetComponent<tk2dSprite>().SetSprite("哇哦");
			break;
		case 2:
			GetComponent<tk2dSprite>().SetSprite("屎掉");
			break;
		case 3:
			GetComponent<tk2dSprite>().SetSprite("开心");
			break;
		case 4:
			GetComponent<tk2dSprite>().SetSprite("得意");
			break;
		case 5:
			GetComponent<tk2dSprite>().SetSprite("惊吓");
			break;
		case 6:
			GetComponent<tk2dSprite>().SetSprite("气喘吁吁");
			break;
		case 7:
			GetComponent<tk2dSprite>().SetSprite("白眼");
			break;
		case 8:
			GetComponent<tk2dSprite>().SetSprite("绝望");
			break;
		case 9:
			GetComponent<tk2dSprite>().SetSprite("谨慎");
			break;
		case 10:
			GetComponent<tk2dSprite>().SetSprite("高兴");
			break;
		}
	}
}
