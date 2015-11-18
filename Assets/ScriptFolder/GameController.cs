using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
	public int LevelNum{get;set;}
	public int LevelScene{get;set;}
	public int LevelSceneNum{get;set;}
	public bool LevelLock{get;set;}
	public bool isCurrent{get;set;}
	public float LevelTime{get;set;}
	public int LevelStars{get;set;}
}

public class GameController  : MonoBehaviour{
	private static GameController instance;  
	public static GameController GetInstance()  
	{  
		if (!instance) 
		{ 
			instance = (GameController)GameObject.FindObjectOfType(typeof(GameController)); 
			
			if (!instance) 
				Debug.LogError("There needs to be one active MyClass script on a GameObject in your scene."); 
		} 
		return instance; 
	}

	//摄像机交互参数
	public bool CameraInitializationState = false;//用于判定摄像机初始化动画是否播放完成，物体在此之后是否可以运动
	public bool  isCameraFollowed = true;//用于令玩家进入观察者模式时屏蔽操作
	public float CameraSizeFollowed;//摄像机跟随时的画面深度
	public float CameraSizeAll;//摄像机在观察者模式时的画面深度
	public float ViewerLeftLine;//摄像机在观察者模式时的左极限
	public float ViewerRightLine;//摄像机在观察者模式时的右极限
	public float ViewerUpLine;//摄像机在观察者模式时的上极限
	public float ViewerDownLine;//摄像机在观察者模式时的下极限
	public float FollowedLeftLine;//摄像机跟随时的左极限
	public float FollowedRightLine;//摄像机跟随时的右极限
	
	///小球
	public enum BallState
	{
		keepIdel,
		move,
		moveInElevator,
	};
	public BallState CurBallState;//小球的运动状态
	public bool IsElevatored = false;//判断小球是否处于电梯中
	public float SpeedMax = 12f;//球机器人移动的限制最大速度
	public bool OnGround = false;//是否接触地面
	public bool JumpJudge = true;//用于矫正小球在斜面多次触发向上的弹跳力的BUG
	public float MovePower = 30.0f;//球机器人移动赋予的力的矢量
	public float JumpPower = 5.0f;//球机器人跳跃赋予的力的矢量
	public bool ShootOnce = true;//用于解决小球被射击多次的问题
	
	///小球与机器人之间的交互参数
	public bool IsRobot = false;//用于判断当前操作对象是否为机器人
	public bool BallToRobot = true;
	public bool PlayerIsTriggered = false;//用于判断小球是否接触到有效机器人
	public GameObject ObjectID;//用于获取小球接触到的有效机器人
	public GameObject ObjectTriggerID;//用于获取小球接触到的有效机器人的触发
	public GameObject CurrentPlayer;//用于选择当前的操作对象
	public GameObject CurrentPlayerTrigger;//用于选择当前的操作对象的触发物体
	public List<GameObject> WorkSpaceCollection = new List<GameObject>();//获得场景中所有的工作台
	public List<GameObject> WorkSpaceCollectionEx = new List<GameObject>();

	///手势操作
	public bool intoRobot = false;//进入机器人
	public bool intoWork = false;//离开机器人
	public bool outWork = false;//进入工作
	public bool outRobot = false;//离开工作
	public int[] moveLeft;//左屏点击
	public int[] moveRight;//右屏点击
	public int[] moveUp;//上屏点击
	public int[] moveDown;//下屏点击
	public Vector2 deltaMove;//拖动坐标

	///教学关卡电影模式参数
	public bool IsOnce = false;//只运行一次
	public bool FilmMode = false;//电影模式
	public string DoorOpener;//开门检测物体的名字
	public Vector3 BallPosition;//记录小球的位置
	public Vector3 Robot01Position;//记录机器人的位置
	public bool AutoOpenDoor02 = false;//开启2号门
	public bool AutoOpenDoor03 = false;//开启3号门
	public bool AutoOpenDoor05 = false;//开启5号门
	public bool Robot02IsDie = false;//检测机器人是否死亡

	//观察者模式参数
	public bool intoViewMode = false;//检测是否进入观察者模式
	public bool outViewMode = false;//检测是否退出观察者模式

	//存档参数
	public int CurrentLevelSceneNum;
	public int CurrentLevelNum;
	public int CurrentLevelScene;
	public List<Level> Levels = new List<Level>();
	public float TimeRecorder = 0;
	
	public void Start () {
		if(Global.GetInstance().SelectedSave == 1 && ES2.Exists ("player01.dat")){
			GameController.GetInstance().CurrentLevelNum = ES2.Load<int>("player01.dat?tag=CurrentLevelNum");
			GameController.GetInstance().CurrentLevelScene = ES2.Load<int>("player01.dat?tag=CurrentLevelScene");
			GameController.GetInstance().CurrentLevelSceneNum = ES2.Load<int>("player01.dat?tag=CurrentLevelSceneNum");
			Levels = ES2.LoadList<Level>("player01.dat?tag=LevelInfo");
		}else if(Global.GetInstance().SelectedSave == 2 && ES2.Exists ("player02.dat")){
			GameController.GetInstance().CurrentLevelNum = ES2.Load<int>("player02.dat?tag=CurrentLevelNum");
			GameController.GetInstance().CurrentLevelScene = ES2.Load<int>("player02.dat?tag=CurrentLevelScene");
			GameController.GetInstance().CurrentLevelSceneNum = ES2.Load<int>("player02.dat?tag=CurrentLevelSceneNum");
			Levels = ES2.LoadList<Level>("player02.dat?tag=LevelInfo");
		}else if(Global.GetInstance().SelectedSave == 3 && ES2.Exists ("player03.dat")){
			GameController.GetInstance().CurrentLevelNum = ES2.Load<int>("player03.dat?tag=CurrentLevelNum");
			GameController.GetInstance().CurrentLevelScene = ES2.Load<int>("player03.dat?tag=CurrentLevelScene");
			GameController.GetInstance().CurrentLevelSceneNum = ES2.Load<int>("player03.dat?tag=CurrentLevelSceneNum");
			Levels = ES2.LoadList<Level>("player03.dat?tag=LevelInfo");
		}
	}
}
