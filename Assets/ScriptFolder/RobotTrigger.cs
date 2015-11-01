using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using System.Collections.Generic;

public class RobotTrigger : MonoBehaviour {
	public string RobotsName;//用于获取当前机器人触发物体的名称
	public string sRobotName;//用于获取当前机器人的前缀（用于寻找对应的工作台）
	int start=1,length=7;//规定字符串截取的方法以获取机器人和工作台的前缀
	public bool IsElevatored = false;//用于判断当前机器人是否处于电梯中
	public bool isNo2 = false;//用于判断当前机器人是否是流水线机器人
	public int isMove = 1;//用于判断是否在工作时可以移动
	public int Count,WorkDelay = 0;
	public float WorkCount;
	public bool PreKeyUp = false;
	public Camera camera01;
	public Camera UIcamera;
	public GameObject WaitCircleParent;
	public GameObject WaitCircle;
	public GameObject Circle;
	private bool isGravity = false;
    private bool _Turn = true;//2号机器人转向
	public bool isBlock_Right = false;//2号机器人工作时被阻挡
	public bool isBlock_Left = false;//2号机器人工作时被阻挡
	public int i;

	void Awake(){
		foreach (Transform child in GameObject.Find("WorkSpace").transform) {
			GameController.GetInstance().WorkSpaceCollection.Add (child.gameObject);
		}
	}

	//获取机器人名称和前缀
	void Start () {
		RobotsName = gameObject.name;
		sRobotName = RobotsName.Substring(start-1, length);
	}
	
	// Update is called once per frame
	void Update () {
		//print (transform.parent.gameObject.GetComponent<Rigidbody>().velocity);
		if (GameController.GetInstance().isCameraFollowed == true && GameController.GetInstance().FilmMode == false) {
			//判断当前机器人是否被警卫击毁
			if (GetComponent<RobotGameOver> ().isAvail == true) {
				//判断当前操作对象是否是机器人且当前机器人是否是玩家机器人
				if (GameController.GetInstance().IsRobot == true && gameObject == GameController.GetInstance().CurrentPlayerTrigger) {
					//判断当前机器人是否处在电梯中
					if (IsElevatored == true) {
						isGravity = false;
						//在电梯中重力取消
						GameController.GetInstance().CurrentPlayer.GetComponent<Rigidbody> ().useGravity = false;
                        if(GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver>().isWork !=true){
						    if (GameController.GetInstance().moveUp[0] == 1) {
						    	//电梯中上移
						    	GameController.GetInstance().CurrentPlayer.transform.Translate (0f, 3f*Time.deltaTime, 0f);
					    	}
					    	if (GameController.GetInstance().moveDown[0] == 1) {
						    	//电梯中下移
						    	GameController.GetInstance().CurrentPlayer.transform.Translate (0f, -3f*Time.deltaTime, 0f);
					    	}
                        }
					} else {
						if(isGravity == false){
							isGravity = true;
							//若不在电梯中，重力恢复
							gameObject.transform.parent.gameObject.GetComponent<Rigidbody> ().useGravity = true;
						}
					}
				
					if (GameController.GetInstance().outRobot == true && GameController.GetInstance().BallToRobot == false) {
						StartCoroutine(ChangeRole());
						//令小球激活
						GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot.gameObject.SetActive (true);
						//将小球的位置定位到当前操作的机器人的位置
						GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().BallRobot.gameObject.transform.position = new Vector3 (GameController.GetInstance().CurrentPlayer.gameObject.transform.position [0], GameController.GetInstance().CurrentPlayer.gameObject.transform.position [1], 0f);
						//将机器人工作状态判定状态改为false
						GameController.GetInstance().IsRobot = false;
						//将当前操作对象和操作对象触发都改为小球
						isMove = 1;
						GameController.GetInstance().CurrentPlayer = GameObject.Find ("BallRobot");
						GameController.GetInstance().CurrentPlayerTrigger = GameObject.Find ("BallRobot");
						//工作台状态改变
						for(Count = 0; Count < GameController.GetInstance().WorkSpaceCollection.Count; Count++){
							if(GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().CurrentPlayerString == GameController.GetInstance().WorkSpaceCollection[Count].gameObject.name.Substring (start - 1, length)){
								GameController.GetInstance().WorkSpaceCollection[Count].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
							}
						}
					}

					//如果 且当前机器人在对应工作台区域且当前机器人为玩家机器人
					if (GameController.GetInstance().intoWork == true && GetComponent<IsWorkSpace> ().isworkspace == true && gameObject == GameController.GetInstance().CurrentPlayerTrigger && GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork == false) {
						isMove = 0;
						//将玩家机器人工作状态设置为true；
						GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork = true;
						//播放工作动画
						GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_work");
						//工作台状态改变
						if (GetComponent<WorkSpaceController> ().isWorkSpacePlay == false) {
							GetComponent<WorkSpaceController> ().isWorkSpacePlay = true;
							GetComponent<WorkSpaceController> ().WorkSpaceControl ();
						}
						if (GameController.GetInstance().CurrentPlayer.name == "Robot_2-Body-1") {
							//c型号机器人工作时有例外
							isNo2 = true;
							if (GetComponent<IsWorkSpace> ().isworkspace == false) {
								GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork = false;
								GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Stop ();
							}
						}
					}

					//离开机器人时，有0.5s的缓冲时间
					if (WorkDelay == 0 && GameController.GetInstance().outWork == true && GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork == true) {
						WorkDelay =(int) (0.5*GameObject.Find("Camera01").gameObject.GetComponent<ShowFrameRate>().Fps);	
						WorkCount = (1f/GameObject.Find("Camera01").gameObject.GetComponent<ShowFrameRate>().Fps);
						Vector3 ScreenPos = camera01.WorldToScreenPoint(transform.position);
						Vector3 LocalPos = UIcamera.ScreenToWorldPoint(ScreenPos);
						Circle = Instantiate(WaitCircle, new Vector3(LocalPos[0],LocalPos[1],-25f), Quaternion.identity) as GameObject;
						Circle.transform.parent = WaitCircleParent.transform;
					}

					if(WorkDelay > 0){
						WorkDelay --;
						Circle.GetComponent<UISprite>().fillAmount = 2*WorkDelay*WorkCount;
						if(WorkDelay == 0){
							Destroy(Circle);
							GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork = false;
							GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Stop ();
							isMove = 1;
							isNo2 = false;
							if (GetComponent<WorkSpaceController> ().isWorkSpacePlay == true) {
								GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
								GetComponent<WorkSpaceController> ().WorkSpaceControl ();
							}
						}
					}

					if(WorkDelay == 0 && PreKeyUp == true){
						PreKeyUp = false;
						GameController.GetInstance().CurrentPlayerTrigger.GetComponent<RobotGameOver> ().isWork = false;
						GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Stop ();
						isMove = 1;
						isNo2 = false;
						if (GetComponent<WorkSpaceController> ().isWorkSpacePlay == true) {
							GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
							GetComponent<WorkSpaceController> ().WorkSpaceControl ();
						}
					}
						
					if (GameController.GetInstance().moveLeft[0] == 1 && GameController.GetInstance().IsRobot == true) {
						if (isMove == 1) {
							GameController.GetInstance().CurrentPlayer.transform.Translate (-1.8f*Time.deltaTime, 0f, 0f);
							//播放左移动画
							GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_walk2");
						} else if (isMove == 0 && isNo2 == true) {
							if (GetComponent<IsWorkSpace> ().isworkspace == true && isBlock_Left == false) {
								GameController.GetInstance().CurrentPlayer.transform.Translate (-1.8f*Time.deltaTime, 0f, 0f);
							}
						}
					}
	
					if (GameController.GetInstance().moveRight[0] == 1 && GameController.GetInstance().IsRobot == true) {
						if (isMove == 1) {
							GameController.GetInstance().CurrentPlayer.transform.Translate (1.8f*Time.deltaTime, 0f, 0f);
							//播放右移动画
							GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_walk");
						} else if (isMove == 0 && isNo2 == true) {
							if (GetComponent<IsWorkSpace> ().isworkspace == true && isBlock_Right == false) {
								GameController.GetInstance().CurrentPlayer.transform.Translate (1.8f*Time.deltaTime, 0f, 0f);
							}
						}
					}
					
					if (GameController.GetInstance().moveLeft[0] == 2) {
						if (isMove == 1) {
							//播放一次移动动画用于缓冲
							GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_walk2");
						}
						GameController.GetInstance().moveLeft[0] = 0;
					}
					
					if (GameController.GetInstance().moveRight[0] == 2) {
						if (isMove == 1) {
							//播放一次移动动画用于缓冲
							GameController.GetInstance().CurrentPlayer.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_walk");
						}
						GameController.GetInstance().moveRight[0] = 0;
					}
					//若当前机器人非玩家机器人
				} else {
					//判断当前机器人是否处在对应工作台处
					if (GetComponent<IsWorkSpace> ().isworkspace == true) {
						//工作状态改为true;
						GetComponent<RobotGameOver> ().isWork = true;
						//播放工作动画
						gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Play (sRobotName + "_work");
						if (GetComponent<WorkSpaceController> ().isWorkSpacePlay == false) {
							GetComponent<WorkSpaceController> ().isWorkSpacePlay = true;
							GetComponent<WorkSpaceController> ().WorkSpaceControl ();
						}
                        //2号机器人工作移动方式
                        if (RobotsName == "Robot_2-1")
                        {
                            if (_Turn)
                            {
                                transform.parent.transform.position = new Vector3(transform.parent.transform.position.x + 0.01f, transform.parent.transform.position.y, transform.parent.transform.position.z);
                            }
                            else {
                                transform.parent.transform.position = new Vector3(transform.parent.transform.position.x - 0.01f, transform.parent.transform.position.y, transform.parent.transform.position.z);
                            }
                        }
					} else if (GetComponent<IsWorkSpace> ().isworkspace == false) {
						//若不在工作台处，工作状态改为false;
						GetComponent<RobotGameOver> ().isWork = false;
						//动画播放暂停
					//	gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Stop ();
						if (GetComponent<WorkSpaceController> ().isWorkSpacePlay == true) {
							GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
							GetComponent<WorkSpaceController> ().WorkSpaceControl ();
						}
					}
				}
			}
		}

	}

	void OnTriggerEnter(Collider IsWin){
		if (IsWin.name == "WinTag") {
			if(Global.GetInstance ().CurrentStayLevel == GameController.GetInstance ().CurrentLevelNum){
				GameController.GetInstance ().CurrentLevelNum = + 1;
				GameController.GetInstance ().CurrentLevelSceneNum = + 1;
				GameController.GetInstance().Levels.Add(
					new Level{
					LevelNum = GameController.GetInstance ().CurrentLevelNum,
					LevelScene = 1,
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
			}
			for(i=0;i < GameController.GetInstance().Levels.Count; i++){
				if(GameController.GetInstance().Levels[i].LevelNum == Global.GetInstance ().CurrentStayLevel && GameController.GetInstance().Levels[i].isCurrent == true){
					GameController.GetInstance().Levels[i].isCurrent = false;
				}
			}
			if(Global.GetInstance().SelectedSave == 1 && ES2.Exists ("player01.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player01.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 2 && ES2.Exists ("player02.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player02.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 3 && ES2.Exists ("player03.dat")){
				ES2.Save(GameController.GetInstance().Levels, "player03.dat?tag=LevelInfo");
			}
			TweenParms Gamewin = new TweenParms ();
			//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
			Gamewin.Prop ("color", new Color (1, 1, 1, 1));
			//回调函数GameOverScene
			Gamewin.OnComplete (GameWinScene);
			HOTween.To (GameObject.Find ("over").gameObject.GetComponent<tk2dSprite> (), 2, Gamewin);
		} else if(IsWin.tag == "Robot_c_Block_Right") {
			//c型号被阻隔
			isBlock_Right = true;
          
		} else if(IsWin.tag == "Robot_c_Block_Left") {
			//c型号被阻隔
			isBlock_Left = true;
            
           
		}
        //2号机器人转向
        if (IsWin.tag == "Robot_c_Block" )
        {
            print("0.0");
             if (_Turn)
            {
                //print("0.0");
                 _Turn = false;
            }
            else
            {
                //print("0.0");
                _Turn = true;
            }
        }
	}

	void OnTriggerStay(Collider IsElevator){
		//如果触发器为电梯
        if (IsElevator.tag == "elevator" || IsElevator.tag == "elevator2")
        {
			//触发中，电梯判断为true；
			IsElevatored = true;
			isGravity=false;
			gameObject.GetComponentInParent<Rigidbody>().useGravity=false;
			gameObject.GetComponentInParent<Rigidbody>().velocity=new Vector3(0,0,0);
		}
	}
	
	void OnTriggerExit(Collider IsElevator){
		//如果触发器为电梯
        if (IsElevator.tag == "elevator" || IsElevator.tag == "elevator2")
        {
			//离开触发，电梯判断为false；
			IsElevatored = false;
		}else if(IsElevator.tag == "Robot_c_Block_Right") {
			//c型号阻隔取消
			isBlock_Right = false;
		}else if(IsElevator.tag == "Robot_c_Block_Left") {
			//c型号阻隔取消
			isBlock_Left = false;
		}
	}
	
	private void GameWinScene(){
		Application.LoadLevel ("DemoWin");
	}

	IEnumerator ChangeRole()  {
		yield return 0;
		GameController.GetInstance().BallToRobot = true;
	}
}
