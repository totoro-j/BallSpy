using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class RobotGameOver : MonoBehaviour {
	public GameObject RobotGameOverTrigger;
	public GameObject BallRobot;
	public GameObject Camera01;
	public GameObject TextAim;
	public GameObject Robot01;
	public GameObject ButtonPause;
	public GameObject ButtonViewer;
	public bool isWork = false;//用于判断当前机器人是否在工作状态
	public bool isAvail = true;//用于判断当前机器人是否有效（可操作）
	private List<GameObject> LightComponent = new List<GameObject>();
	private bool isDeath = false;
	private GameObject IsRobotWorks;
	private bool JudgeOnce = true;//令触发结算只结算一次
	string MyName;
	int start=1,length=8;
	int Count;

	void Awake(){
		foreach (Transform child in GameObject.Find("WorkSpace").transform) {
			GameController.GetInstance().WorkSpaceCollection.Add (child.gameObject);
		}
	}
	
	void Start () {
		MyName = gameObject.name.Substring (start - 1, length);
	}

	//用于机器人作为操作对象时遇到类型1警卫的GameOver结算
	void Update(){
		//如果遇到类型1警卫且当前机器人不在工作
		if(RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsTriggered == true && GetComponent<RobotTrigger>().IsActive == true){
			if (RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().isGuard_b == true && isWork == false) {
				RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().isGuard_b = false;
				IsRobotWorks = RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsGameOver.gameObject;
				if(JudgeOnce == true){
					foreach (Transform child in RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsGameOver.transform.parent.transform.parent.transform) {
						LightComponent.Add (child.gameObject);
					}
					//如果当前机器人为玩家机器人
					if (gameObject.transform.parent.gameObject == GameController.GetInstance().CurrentPlayer && Application.loadedLevelName != "DemoTech") {
						JudgeOnce = false;
						isAvail = false;
						gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().Sleep();
						WaitNow();
						//新建整体的HOTween补间动画
						TweenParms Gameover = new TweenParms ();
						//新建当前机器人的HOTween补间动画
						TweenParms DestoryRobotAnim = new TweenParms ();
						//颜色渐渐变黑
						DestoryRobotAnim.Prop ("color", new Color (0, 0, 0, 1));
						HOTween.To (gameObject.transform.parent.gameObject.GetComponent<tk2dSprite> (), 0.2f, DestoryRobotAnim);
						//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
						Gameover.Prop ("color", new Color (1, 1, 1, 1));
						//回调函数GameOverScene
						Gameover.OnComplete (GameOverScene);
						HOTween.To (GameObject.Find ("over").gameObject.GetComponent<tk2dSprite> (), 2, Gameover);
						LightComponent[0].GetComponent<tk2dSprite>().SetSprite("红灯");
						LightComponent[1].GetComponent<tk2dSprite>().SetSprite("红光");
						StartCoroutine(WaitLight(2.0f));
						//如果不是玩家机器人
					}else if(gameObject.transform.parent.gameObject == GameController.GetInstance().CurrentPlayer && Application.loadedLevelName == "DemoTech" && GameController.GetInstance ().FilmMode == false){
						JudgeOnce = true;
						BallRobot.SetActive(true);
						GameController.GetInstance ().FilmMode = true;
						ButtonPause.GetComponent<UIButton> ().isEnabled = false;
						ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
						TextAim.GetComponent<UILabel>().text = "放轻松，我们再试一次。";
						for(Count = 0; Count < GameController.GetInstance ().WorkSpaceCollection.Count; Count++){
							if(GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().CurrentPlayerString == GameController.GetInstance ().WorkSpaceCollection[Count].gameObject.name.Substring (start - 1, length)){
								GameController.GetInstance ().WorkSpaceCollection[Count].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
							}
						}
						TweenParms Action03 = new TweenParms ();
						Action03.Prop ("position", new Vector3 (GameController.GetInstance().BallPosition [0], GameController.GetInstance().BallPosition [1], -21.3f));
						Action03.Ease (EaseType.EaseOutQuart);		
						HOTween.To (Camera01.transform, 2.0f, Action03);
						BallRobot.transform.position = GameController.GetInstance().BallPosition;
						Robot01.transform.position = GameController.GetInstance().Robot01Position;
						GameController.GetInstance().CurrentPlayer = BallRobot;
						GameController.GetInstance().CurrentPlayerTrigger = BallRobot;
						GameController.GetInstance().IsRobot = false;
						GameController.GetInstance().BallToRobot = true;
						StartCoroutine (Miss (1.5f));
					}else if(gameObject.transform.parent.gameObject != GameController.GetInstance().CurrentPlayer && isDeath == false){
						JudgeOnce = false;
						WaitNow();
						gameObject.transform.parent.gameObject.GetComponent<Rigidbody>().Sleep();
						//机器人失效，不能操作
						isAvail = false;
						//当前tag标签改为NoRobot
						gameObject.tag = "NoRobot";
						//新建当前机器人的HOTween补间动画
						TweenParms DestoryRobotAnim = new TweenParms ();
						//颜色渐渐变黑
						DestoryRobotAnim.Prop ("color", new Color (0, 0, 0, 1));
						HOTween.To (gameObject.transform.parent.gameObject.GetComponent<tk2dSprite> (), 0.2f, DestoryRobotAnim);
						LightComponent[1].GetComponent<tk2dSprite>().SetSprite("红灯");
						LightComponent[0].GetComponent<tk2dSprite>().SetSprite("红光");
						if(gameObject.transform.parent.gameObject.name == "Robot_a1-Body-3-SP"){
							GameController.GetInstance ().Robot02IsDie = true;
						}
						if(GameController.GetInstance ().FilmMode == true){
							
							for(Count = 0; Count < GameController.GetInstance ().WorkSpaceCollection.Count; Count++){
								if(MyName == GameController.GetInstance ().WorkSpaceCollection[Count].gameObject.name.Substring (start - 1, length)){
									GameController.GetInstance ().WorkSpaceCollection[Count].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
								}
							}
						}
						StartCoroutine(WaitLight(2.0f));
					}
				}
			}
			//如果遇到了警卫3并且还被控制状态
			if (RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().isGuard_c == true && gameObject.transform.parent.gameObject == GameController.GetInstance().CurrentPlayer && Application.loadedLevelName != "DemoTech"){
				RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().isGuard_c = false;
				if (JudgeOnce == true)
				{
					foreach (Transform child in RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsGameOver.transform.parent.transform.parent.transform)
					{
						//获得警卫的组件
						LightComponent.Add(child.gameObject);
					}
					JudgeOnce = false;
					//新建警卫的HOTween补间动画
					Sequence Guard02Alert = new Sequence(new SequenceParms().Loops(10, LoopType.Restart));
					//警卫颜色闪烁
					Guard02Alert.Prepend(HOTween.To(RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsGameOver.gameObject.GetComponent<tk2dSprite>(), 0.08f, new TweenParms().Prop("color", new Color(1f, 1f, 1f, 0.5f))));
					Guard02Alert.Append(HOTween.To(RobotGameOverTrigger.gameObject.GetComponent<RobotGameOverTrigger>().IsGameOver.gameObject.GetComponent<tk2dSprite>(), 0.08f, new TweenParms().Prop("color", new Color(1f, 1f, 1f, 1f))));
					Guard02Alert.Play();
					//计算粒子子弹发射角度
					float ShootAngle01 = Vector3.Angle(
						new Vector3(100f, 0f, 0f),
						transform.position * 100.0f - LightComponent[1].transform.position * 100.0f)
						* -Mathf.Sign(
							Vector3.Cross(
							new Vector3(100f, 0f, 0f), transform.position * 100.0f - LightComponent[1].transform.position * 100.0f)[2]);
					LightComponent[1].transform.rotation = Quaternion.Euler(ShootAngle01, 90, 0);
					LightComponent[1].GetComponent<ParticleSystem>().Play();
					//新建整体的HOTween补间动画
					TweenParms Gameover = new TweenParms();
					//新建当前机器人的HOTween补间动画
					TweenParms DestoryRobotAnim = new TweenParms();
					//颜色渐渐变黑
					DestoryRobotAnim.Prop("color", new Color(0, 0, 0, 1));
					HOTween.To(gameObject.transform.parent.gameObject.GetComponent<tk2dSprite>(), 0.2f, DestoryRobotAnim);
					//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
					Gameover.Prop("color", new Color(1, 1, 1, 1));
					//回调函数GameOverScene
					Gameover.OnComplete(GameOverScene);
					HOTween.To(GameObject.Find("over").gameObject.GetComponent<tk2dSprite>(), 2, Gameover);
				}
			}
		}
	}

	private void GameOverScene(){
		//场景时间冻结（初始默认为1）
		Time.timeScale = 0;
		Application.LoadLevel ("DemoOver");
	}

	IEnumerator Miss(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 ( BallRobot.transform.position[0], BallRobot.transform.position[1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		StartCoroutine(waitRe(2.0f));
	}

	IEnumerator waitRe(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		GameController.GetInstance ().FilmMode = false;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
		TextAim.GetComponent<UILabel>().text = " ";
	}

	void WaitNow(){
		isDeath = true;
		float ShootAngle01 = Vector3.Angle(
			new Vector3(100f,0f,0f),
			transform.position*100.0f-LightComponent[3].transform.position*100.0f)
			*-Mathf.Sign(
				Vector3.Cross(
				new Vector3(100f,0f,0f),transform.position*100.0f-LightComponent[3].transform.position*100.0f)[2]);
		LightComponent[3].transform.rotation = Quaternion.Euler(ShootAngle01,90,0);
		LightComponent[3].GetComponent<ParticleSystem>().Play();
		//新建警卫的HOTween补间动画
		Sequence Guard01Alert = new Sequence (new SequenceParms().Loops(10,LoopType.Restart));
		//警卫颜色闪烁
		Guard01Alert.Prepend(HOTween.To (IsRobotWorks.gameObject.GetComponent<tk2dSprite> (), 0.08f,new TweenParms().Prop("color", new Color (1f, 1f, 1f, 1f))));
		Guard01Alert.Append(HOTween.To (IsRobotWorks.gameObject.GetComponent<tk2dSprite> (), 0.08f,new TweenParms().Prop("color", new Color (1f, 1f, 1f, 0.5f))));
		Guard01Alert.Play();
	}

	IEnumerator WaitLight(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		LightComponent[0].GetComponent<tk2dSprite>().SetSprite("绿灯");
		LightComponent[1].GetComponent<tk2dSprite>().SetSprite("绿光"); 
		JudgeOnce = true;
	}
}
