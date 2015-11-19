using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class SceneTechAnimControl : MonoBehaviour {
	//教学关卡流程
	public GameObject Robot01;
	public GameObject Robot02;
	public GameObject Robot01Trigger;
	public GameObject RobotFirstTrigger;
	public GameObject Robot03Trigger;
	public GameObject Robot04Trigger;
	public GameObject Robot03;
	public GameObject BallRobot;
	public GameObject BallRobot01;
	public GameObject BallRobot02;
	public GameObject ButtonPause;
	public GameObject ButtonViewer;
	public GameObject BlackLine01;
	public GameObject BlackLine02;
	public Camera Camera01;
	public GameObject phone;
	public GameObject Door01;
	public GameObject Door02;
	public GameObject Door03;
	public GameObject Door04;
	public GameObject Door05;
	public GameObject Door06;
	public GameObject Door07;
	public GameObject Door08;
	public GameObject DoorOpener01;
	public GameObject Pos1;
	public GameObject Pos2;
	public GameObject Pos3;
	public GameObject Pos4;
	public GameObject Circle01;
	public GameObject Circle02;
	public GameObject Circle03;
	public GameObject Circle04;
	public GameObject Circle05;
	public GameObject Arrow01;
	public GameObject Arrow02;
	public GameObject Arrow03;
	public GameObject Arrow04;
	public GameObject TextAim;
	public GameObject MissingBallPlayer;//用于绑定小球进入机器人的动画中白色小球的预设
	public GameObject Guard01;
	public GameObject Guard01Control;
	bool isGoDie = false;
	bool isRobotGoDie = false;
	bool isSolve = false;
	bool isRobotSolve = false;
	bool isRobotKeepMove = false;
	bool isOver = false;
	bool isGuardArrived = false;
	bool isUpSwiped = false;
	bool isUpOnce = false;
	bool isDownSwiped = false;
	bool isDownOnce = false;
	bool isOutRobot = false;
	bool isFinalRush = false;
	string MyName;
	int isRight = 0;
	int isLeft = 0;
	int isUp = 0;
	int isIntoView = 4;
	int isView = 0;
	int isOutView = 0;
	int start=1,length=8;
	int WorkCounts;
	GameObject MissingBall;//用于初始化白色小球
	GameObject TempCurrentPlayerTrigger; //用于缓存当前控制物体
	GameObject TempCurrentPlayer;
	Sequence RightFingerTap;
	Sequence LeftFingerTap;
	Sequence UpFingerTap;
	Sequence IntoViewTap;
	Sequence ViewTap;
	Sequence OutViewTap;
	Sequence UpFingerSwipe;
	Sequence DownFingerSwipe;

	void Awake(){
		foreach (Transform child in GameObject.Find("WorkSpace").transform) {
			GameController.GetInstance().WorkSpaceCollection.Add (child.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Circle01.SetActive (false);
		Circle02.SetActive (false);
		Circle03.SetActive (false);
		Circle04.SetActive (false);
		Circle05.SetActive (false);
		Arrow01.SetActive (false);
		Arrow02.SetActive (false);
		Arrow03.SetActive (false);
		Arrow04.SetActive (false);
		DoorOpener01.SetActive (false);
		GameController.GetInstance ().Robot01Position = new Vector3 (-37.77902f, -2.061617f, 0.3000002f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {;
		if (GameController.GetInstance ().CameraInitializationState == true && Application.loadedLevelName == "DemoTech") {
			switch (GameController.GetInstance ().DoorOpener) {
			case "DoorOpener01":
				Ball01GoDie ();
				Ball02Solve ();
				Robot03Over ();
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim01 ();
				}
				break;
			case "DoorOpener04":
				Robot02GoDie();
				Robot03Solve();
				WaitNextRobot();
				WaitKeepMove();
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim02 ();
				}
				break;
			case "DoorOpener0501":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim0201 ();
				}
				break;
			case "DoorOpener0502":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim0202 ();
				}
				break;
			case "DoorOpener06":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim03 ();
				}
				break;
			case "DoorOpener07":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim04 ();
				}
				break;
			case "DoorOpener08":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim05 ();
				}
				break;
			case "DoorOpener09":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim06 ();
				}
				break;
			case "DoorOpenerPos2":
				if (GameController.GetInstance ().IsOnce == true) {
					GameController.GetInstance ().IsOnce = false;
					Anim07 ();
				}
				break;
			}

			FingerRight();
			FingerLeft();
			FingerUp();
			ViewerModeInto();
			ViewerMode();
			ViewerModeOut();
			FingerUpSwipe();
			FingerDownSwipe();
			WaitOutRobot();
			FinalRush();
		}
	}
	//PART1
	void FingerRight() 
	{   
		if(isRight == 0){
			isRight = 1;
			Circle01.SetActive (true);
			TextAim.GetComponent<UILabel>().text = "按住右键向右移动";
			RightFingerTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			RightFingerTap.Prepend(HOTween.To (Circle01.transform, 1.2f, new TweenParms ().Prop ("localScale", new Vector3(1.2f,1.2f,0f)).Ease (EaseType.EaseInOutQuint)));
			RightFingerTap.Insert (0,HOTween.To (Circle01.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(0.6f,0.6f,0.6f,0f)).Ease (EaseType.EaseInOutQuint)));
			RightFingerTap.Play ();
		}
		if(GameController.GetInstance().moveRight[0] == 1 && isRight == 1){
			isRight = 2;
			RightFingerTap.Kill();
			Circle01.SetActive(false);
		}
	}

	void FingerLeft() 
	{   
		if(isLeft == 0 && isRight == 2){
			isLeft = 1;
			Circle02.SetActive (true);
			TextAim.GetComponent<UILabel>().text = "按住左键向左移动";
			LeftFingerTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			LeftFingerTap.Prepend(HOTween.To (Circle02.transform, 1.2f, new TweenParms ().Prop ("localScale", new Vector3(1.2f,1.2f,0f)).Ease (EaseType.EaseInOutQuint)));
			LeftFingerTap.Insert (0,HOTween.To (Circle02.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(0.6f,0.6f,0.6f,0f)).Ease (EaseType.EaseInOutQuint)));
			LeftFingerTap.Play ();
		}
		if(GameController.GetInstance().moveLeft[0] == 1 && isLeft == 1){
			isLeft = 2;
			LeftFingerTap.Kill();
			Circle02.SetActive(false);
		}
	}

	void FingerUp(){  
			if(isUp == 0 && isLeft == 2){
				isUp = 1;
				Circle03.SetActive (true);
				TextAim.GetComponent<UILabel>().text = "轻按上键小球向上跳跃";
				UpFingerTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
				UpFingerTap.Prepend(HOTween.To (Circle03.transform, 1.2f, new TweenParms ().Prop ("localScale", new Vector3(1.2f,1.2f,0f)).Ease (EaseType.EaseInOutQuint)));
				UpFingerTap.Insert (0,HOTween.To (Circle03.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(0.6f,0.6f,0.6f,0f)).Ease (EaseType.EaseInOutQuint)));
				UpFingerTap.Play ();
			}
			if(GameController.GetInstance().moveUp[0] == 1 && isUp == 1){
				isUp = 2;
				UpFingerTap.Kill();
				DoorOpener01.SetActive(true);
				Circle03.SetActive(false);
				TextAim.GetComponent<UILabel>().text = "前进！目标：潜入敌方工厂设施！";
			}
	}

	//PART2
	void Anim01(){
		TextAim.GetComponent<UILabel>().text = " ";
		GameController.GetInstance ().FilmMode = true;
		GameController.GetInstance ().BallPosition = Pos1.gameObject.transform.position;
		ButtonPause.GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		BallRobot.GetComponent<Rigidbody>().Sleep();
		TweenPosition tween01 = TweenPosition.Begin (BlackLine01 , 0.5f , new Vector3(10,55f,0));
		TweenPosition tween02 = TweenPosition.Begin (BlackLine02 , 0.5f , new Vector3(10,-45f,0));
		Door01.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
		StartCoroutine(WaitBall(2.5f));
	}
	
	IEnumerator WaitBall(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		Door01.SetActive(false);
		TweenParms Action01 = new TweenParms();
		Action01.Prop("position", new Vector3(BallRobot01.transform.position[0],BallRobot01.transform.position[1],-21.3f));
		Action01.Ease (EaseType.EaseOutQuart);
		Action01.OnComplete(GoDie);	
		HOTween.To(Camera01.transform,1.5f,Action01);
	}
	
	void Ball01GoDie(){
		if(isGoDie == true && GameController.GetInstance().ShootOnce == true){
			TextAim.GetComponent<UILabel>().text = "注意！间谍小球会被反间谍警卫的红色射线识别并击毁。";
			BallRobot01.GetComponent<Rigidbody> ().AddForce (GameController.GetInstance().MovePower, 0, 0);		
			Camera01.transform.position = new Vector3 (BallRobot01.transform.position[0], BallRobot01.transform.position[1], -21.3f);
		}
	}

	void Ball02Solve(){
		if (isSolve == true && GameController.GetInstance ().PlayerIsTriggered == false && GameController.GetInstance ().AutoOpenDoor02 == false) {
			TextAim.GetComponent<UILabel>().text = "因此我们需要使用间谍小球的特殊技能：机械附着。";
			BallRobot02.GetComponent<Rigidbody> ().AddForce (-GameController.GetInstance ().MovePower, 0, 0);			
			Camera01.transform.position = new Vector3 (BallRobot02.transform.position [0], BallRobot02.transform.position [1], -21.3f);
		} else if (GameController.GetInstance ().AutoOpenDoor02 == true && GameController.GetInstance ().IsOnce == true) {
			GameController.GetInstance ().IsOnce = false;
			BallRobot02.GetComponent<Rigidbody> ().Sleep ();
			Door02.GetComponent<tk2dSpriteAnimator> ().Play ("DoorOpen");
			StartCoroutine (WaitDoor (1.2f));
		} else if (GameController.GetInstance ().PlayerIsTriggered == true && GameController.GetInstance ().ObjectID.name == "Robot_a1-Body-2-SP") {
			TextAim.GetComponent<UILabel>().text = "试着手指向上滑屏，附着进这个机器人体内！";
			GameController.GetInstance ().CurrentPlayer = BallRobot02;
			isUpSwiped = true;
			isSolve = false;
			BallRobot02.GetComponent<Rigidbody> ().Sleep ();
			if (GameController.GetInstance ().intoRobot == true) {
				BallRobot02.gameObject.SetActive (false);
				MissingBall = Instantiate (MissingBallPlayer, BallRobot02.gameObject.transform.position, Quaternion.identity) as GameObject;
				Sequence BallAnim = new Sequence (new SequenceParms ());	
				BallAnim.Prepend (HOTween.To (Camera01.gameObject.transform, 0.3f, new TweenParms ().Prop ("position", new Vector3 (Robot01.transform.position [0], Robot01.transform.position [1], -21.3f))));
				BallAnim.Insert (0, HOTween.To (MissingBall.gameObject.transform, 0.15f, new TweenParms ().Prop ("localScale", new Vector3 (0.1f, 1.5f, 1f))));
				BallAnim.Insert (0.1f, HOTween.To (MissingBall.gameObject.transform, 0.2f, new TweenParms ().Prop ("position", new Vector3 (MissingBall.gameObject.transform.position [0], MissingBall.gameObject.transform.position [1] + 2.3f, MissingBall.gameObject.transform.position [2]))));
				BallAnim.Insert (0.2f, HOTween.To (MissingBall.gameObject.GetComponent<tk2dSprite> (), 0.1f, new TweenParms ().Prop ("color", new Color (1, 1, 1, 0))));
				BallAnim.Play ();
				//被操作的机器人（玩家机器人）半透明状态还原
				GameController.GetInstance().ObjectID.gameObject.GetComponent<tk2dSprite>().color = new Color(1f, 1f, 1f, 1.0f);
				TweenParms Action05 = new TweenParms ();
				Action05.Prop ("position", new Vector3 (Robot01.transform.position [0], Robot01.transform.position [1], -21.3f));
				Action05.Ease (EaseType.EaseOutQuart);
				HOTween.To (Camera01.transform, 0.3f, Action05);
				GameController.GetInstance ().CurrentPlayerTrigger = Robot01Trigger;
				GameController.GetInstance ().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().isWorkSpacePlay = true;
				if( GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().isWorkSpacePlay == true){
					GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().isWorkSpacePlay = false;
					GameController.GetInstance().CurrentPlayerTrigger.GetComponent<WorkSpaceController>().WorkSpaceControl();
				}
				StartCoroutine (WaitRobot(0.8f));
			}
		}
	}

	void FingerUpSwipe(){
		if(isUpSwiped == true && isUpOnce == false){
			isUpOnce = true;
			isUpSwiped = false;
			Arrow01.SetActive (true);
			UpFingerSwipe = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			UpFingerSwipe.Prepend(HOTween.To (Arrow01.GetComponent<UISprite>(), 0.01f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,1f)).Ease (EaseType.EaseInOutQuint)));
			UpFingerSwipe.Insert(0.01f,HOTween.To (Arrow01.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,0f)).Ease (EaseType.EaseInOutQuint)));
			UpFingerSwipe.Insert(0.01f,HOTween.To (Arrow01.transform, 1.2f, new TweenParms ().Prop ("position", new Vector3(Arrow01.transform.position[0], Arrow01.transform.position[1]+30f, Arrow01.transform.position[2])).Ease (EaseType.EaseInOutQuint)));
			UpFingerSwipe.Play ();
		}
	}

	void FingerDownSwipe(){
		if(isDownSwiped == true && isDownOnce == false){
			isDownOnce = true;
			isDownSwiped = false;
			Arrow02.SetActive (true);
			DownFingerSwipe = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			DownFingerSwipe.Prepend(HOTween.To (Arrow02.GetComponent<UISprite>(), 0.01f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,1f)).Ease (EaseType.EaseInOutQuint)));
			DownFingerSwipe.Insert(0.01f,HOTween.To (Arrow02.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,0f)).Ease (EaseType.EaseInOutQuint)));
			DownFingerSwipe.Insert(0.01f,HOTween.To (Arrow02.transform, 1.2f, new TweenParms ().Prop ("position", new Vector3(Arrow02.transform.position[0], Arrow02.transform.position[1]-30f, Arrow02.transform.position[2])).Ease (EaseType.EaseInOutQuint)));
			DownFingerSwipe.Play ();
		}
	}
	
	IEnumerator WaitDoor(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		GameController.GetInstance().AutoOpenDoor02 = false;
		Door02.SetActive(false);
	}

	IEnumerator WaitRobot(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		isOver = true;
		GameController.GetInstance ().PlayerIsTriggered = false;
	}

	void Robot03Over(){
		if (isOver == true && GameController.GetInstance ().AutoOpenDoor03 == false) {
			TextAim.GetComponent<UILabel>().text = "间谍小球成功控制了一台工作机器人！以附着的机器人作为伪装，就可以轻松躲过反间谍警卫的扫描。";
			GameController.GetInstance ().CurrentPlayer = Robot01;
			GameController.GetInstance ().CurrentPlayerTrigger = Robot01Trigger;
			isUpOnce = false;
			UpFingerSwipe.Kill();
			Arrow01.SetActive(false);
			Robot01.transform.Translate (1.8f*Time.deltaTime, 0f, 0f);
			Robot01.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");			
			Camera01.transform.position = new Vector3 (Robot01.transform.position [0], Robot01.transform.position [1], -21.3f);
		}else if(GameController.GetInstance().AutoOpenDoor03 == true && GameController.GetInstance().IsOnce == true){
			Destroy (MissingBall);
			isOver = false;
			GameController.GetInstance().IsOnce = false;
			Robot01.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");
			Door03.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
			StartCoroutine(WaitOver(2.0f));
		}
	}

	IEnumerator WaitNextBall(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		isGoDie = false;
		TweenParms Action02 = new TweenParms();
		Action02.Prop("position", new Vector3(BallRobot02.transform.position[0],BallRobot02.transform.position[1],-21.3f));
		Action02.Ease (EaseType.EaseOutQuart);
		Action02.OnComplete(Solve);		
		HOTween.To(Camera01.transform,1.5f,Action02);
	}

	IEnumerator WaitOver(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		Door03.SetActive(false);
		Robot01.SetActive(false);
		BallRobot.GetComponent<Rigidbody> ().WakeUp ();
		GameController.GetInstance ().CurrentPlayer = BallRobot;
		GameController.GetInstance ().CurrentPlayerTrigger = BallRobot;
		TextAim.GetComponent<UILabel>().text = "我方间谍小球已经为你打开了下一入口的通行大门！请尽快赶过去！";
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (BallRobot.transform.position [0], BallRobot.transform.position [1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		TweenPosition tween03 = TweenPosition.Begin (BlackLine01, 0.5f, new Vector3 (0, 65.09f, 0));
		TweenPosition tween04 = TweenPosition.Begin (BlackLine02, 0.5f, new Vector3 (0, -65.09f, 0));
		StartCoroutine(WaitExit(2.2f));
	}

	IEnumerator WaitExit(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		TextAim.GetComponent<UILabel>().text = " ";
		GameController.GetInstance ().FilmMode = false;
		GameController.GetInstance ().CurrentPlayer = BallRobot.gameObject;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
		StartCoroutine(WaitText(4.0f));
	}

	void GoDie(){
		isGoDie = true;
		StartCoroutine(WaitNextBall(4.5f));
	}
	
	void Solve(){
		isSolve = true;
	}

	IEnumerator WaitText(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		TextAim.GetComponent<UILabel>().text = " ";
	}

	//PART3
	void Anim02(){
		GameController.GetInstance ().FilmMode = true;
		GameController.GetInstance ().BallPosition = Pos2.gameObject.transform.position;
		GameController.GetInstance ().Robot01Position = Pos2.gameObject.transform.position;
		TempCurrentPlayerTrigger = GameController.GetInstance ().CurrentPlayerTrigger;
		TempCurrentPlayer = GameController.GetInstance ().CurrentPlayer;
		ButtonPause.GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		BallRobot.GetComponent<Rigidbody>().Sleep();
		TweenPosition tween01 = TweenPosition.Begin (BlackLine01 , 0.5f , new Vector3(0,48.9f,0));
		TweenPosition tween02 = TweenPosition.Begin (BlackLine02 , 0.5f , new Vector3(0,-48.9f,0));
		TextAim.GetComponent<UILabel>().text = "等等！我方间谍前哨正在为各位探路。";
		StartCoroutine(WaitRobots(2.5f));
	}

	IEnumerator WaitRobots(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		GameController.GetInstance ().CurrentPlayerTrigger = Robot04Trigger;
		MyName = GameController.GetInstance ().CurrentPlayerTrigger.transform.parent.name.Substring (start - 1, length);
		for(WorkCounts = 0; WorkCounts < GameController.GetInstance().WorkSpaceCollection.Count; WorkCounts++){
			if(MyName == GameController.GetInstance().WorkSpaceCollection[WorkCounts].gameObject.name.Substring (start - 1, length) && GameController.GetInstance().WorkSpaceCollection[WorkCounts].CompareTag( "workspace")){
				GameController.GetInstance().WorkSpaceCollection[WorkCounts].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
				GameController.GetInstance().WorkSpaceCollectionEx.Add(GameController.GetInstance().WorkSpaceCollection[WorkCounts]);
			}
		}
		TweenParms Action06 = new TweenParms();
		Action06.Prop("position", new Vector3(Robot02.transform.position[0],Robot02.transform.position[1],-21.3f));
		Action06.Ease (EaseType.EaseOutQuart);
		Action06.OnComplete(RobotGoDie);		
		HOTween.To(Camera01.transform,1.5f,Action06);
	}

	void RobotGoDie(){
		isRobotGoDie = true;
	}

	void Robot02GoDie(){
		if(isRobotGoDie == true){
			TextAim.GetComponent<UILabel>().text = "哦，糟糕。似乎……我们遇到了新的敌人——监工警卫。";
			Robot02.transform.Translate (1.8f*Time.deltaTime, 0f, 0f);
			Robot02.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");		
			Camera01.transform.position = new Vector3 (Robot02.transform.position[0], Robot02.transform.position[1], -21.3f);
		}
	}

	void Robot03Solve(){
		if (isRobotSolve == true && isGuardArrived == false && Guard01.transform.position [0] < 26.95f) {
			isGuardArrived = true;
		}

		if (Robot03Trigger.GetComponent<IsWorkSpace> ().isworkspace == true && isRobotSolve == true && Robot03.transform.position[0] > 35.0f) {
			TextAim.GetComponent<UILabel>().text = "就是这里！接下来试着手指向上滑屏，把机器人切换到工作模式。";
			isRobotSolve = false;
			isUpSwiped = true;
			Robot03.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");
			Guard01Control.GetComponent<Guard_a_Moving>().Guard_a_Movement.Pause();
		}

		if (isRobotSolve == true && isGuardArrived == true) {
			TextAim.GetComponent<UILabel>().text = "出发！跟在监工警卫身后，以确保万无一失。";
			GameController.GetInstance ().CurrentPlayerTrigger = Robot03Trigger;
			GameController.GetInstance().IsRobot = true;
			GameController.GetInstance().intoRobot = false;
			Robot03.transform.Translate (1.8f * Time.deltaTime, 0f, 0f);
			Robot03.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");
			Camera01.transform.position = new Vector3 (Robot03.transform.position [0], Robot03.transform.position [1], -21.3f);
		}

		if (GameController.GetInstance ().intoWork == true && Robot03Trigger.GetComponent<IsWorkSpace> ().isworkspace == true) {
			TextAim.GetComponent<UILabel>().text = "干得漂亮！在工作模式下，监工机器人是不会发现异常的。";
			UpFingerSwipe.Kill();
			Arrow01.SetActive(false);
			isUpOnce = false;
			Guard01Control.GetComponent<Guard_a_Moving>().Guard_a_Movement.Play();
			Robot03.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_work");
			Robot03Trigger.GetComponent<RobotGameOver> ().isWork = true;
			if (Robot03Trigger.GetComponent<WorkSpaceController> ().isWorkSpacePlay == false) {
				Robot03Trigger.GetComponent<WorkSpaceController> ().isWorkSpacePlay = true;
				Robot03Trigger.GetComponent<WorkSpaceController> ().WorkSpaceControl ();
			}
		}

		if(Robot03Trigger.GetComponent<RobotGameOver> ().isWork == true && Guard01.transform.position [0] < 26.95f){
			TextAim.GetComponent<UILabel>().text = "监工机器人已经离开得足够远！趁现在，手指向下滑屏，令机器人脱离工作模式。";
			isDownSwiped = true;
			Guard01Control.GetComponent<Guard_a_Moving>().Guard_a_Movement.Pause();
		}

		if (GameController.GetInstance ().outWork == true && Robot03Trigger.GetComponent<RobotGameOver> ().isWork == true && Guard01.transform.position [0] < 32.0f && Guard01Control.GetComponent<Guard_a_Moving>().Guard_a_Movement.isPaused == true) {
			if (Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay == 0) {				
				Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay = (int)(0.5 * GameObject.Find ("Camera01").gameObject.GetComponent<ShowFrameRate> ().Fps);	
				Robot03Trigger.GetComponent<RobotTrigger> ().WorkCount = (1f / GameObject.Find ("Camera01").gameObject.GetComponent<ShowFrameRate> ().Fps);
				Vector3 ScreenPos = Robot03Trigger.GetComponent<RobotTrigger> ().camera01.WorldToScreenPoint (Robot03Trigger.transform.position);
				Vector3 LocalPos = Robot03Trigger.GetComponent<RobotTrigger> ().UIcamera.ScreenToWorldPoint (ScreenPos);
				Robot03Trigger.GetComponent<RobotTrigger> ().Circle = Instantiate (Robot03Trigger.GetComponent<RobotTrigger> ().WaitCircle, new Vector3 (LocalPos [0], LocalPos [1], -25f), Quaternion.identity) as GameObject;
				Robot03Trigger.GetComponent<RobotTrigger> ().Circle.transform.parent = Robot03Trigger.GetComponent<RobotTrigger> ().WaitCircleParent.transform;
			}
		}

		if (Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay > 0) {
			Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay --;
			Robot03Trigger.GetComponent<RobotTrigger> ().Circle.GetComponent<UISprite> ().fillAmount = 2 * Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay * Robot03Trigger.GetComponent<RobotTrigger> ().WorkCount;
			if (Robot03Trigger.GetComponent<RobotTrigger> ().WorkDelay == 0) {
				Guard01Control.GetComponent<Guard_a_Moving>().Guard_a_Movement.Play();
				Destroy (Robot03Trigger.GetComponent<RobotTrigger> ().Circle);
				Robot03Trigger.GetComponent<RobotGameOver> ().isWork = false;
				Robot03.GetComponent<tk2dSpriteAnimator> ().Stop ();
				if (Robot03Trigger.GetComponent<WorkSpaceController> ().isWorkSpacePlay == true) {
					Robot03Trigger.GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
					Robot03Trigger.GetComponent<WorkSpaceController> ().WorkSpaceControl ();
				}
				StartCoroutine (WaitMov (0.8f));
			}
		}
	}

	void WaitKeepMove() //等待的时间,单位秒  
	{   
		if(isRobotKeepMove == true){
			TextAim.GetComponent<UILabel>().text = "天啦噜！监工机器人追过来了！快！快！快！";
			DownFingerSwipe.Kill();
			Arrow02.SetActive(false);
			isDownOnce = false;
			Robot03.transform.Translate (1.8f * Time.deltaTime, 0f, 0f);
			Robot03.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");		
			Camera01.transform.position = new Vector3 (Robot03.transform.position [0], Robot03.transform.position [1], -21.3f);
		}
		if(GameController.GetInstance().AutoOpenDoor05 == true && GameController.GetInstance().IsOnce == true){
			TextAim.GetComponent<UILabel>().text = "成功了！我们躲过了监工机器人的扫描。";
			isRobotKeepMove = false;
			GameController.GetInstance().IsOnce = false;
			Robot03.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_a1_walk");
			Door04.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
			StartCoroutine(WaitRobotOver(2.0f));
		}
	}

	IEnumerator WaitRobotOver(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		Robot03.SetActive(false);
		Door04.SetActive (false);
		BallRobot.GetComponent<Rigidbody> ().WakeUp ();
		TextAim.GetComponent<UILabel>().text = "接下来，轮到你了。";
		if (TempCurrentPlayer == BallRobot) {
			GameController.GetInstance ().IsRobot = false;
			GameController.GetInstance ().BallToRobot = true;
			MyName = GameController.GetInstance ().CurrentPlayer.name.Substring (start - 1, length);
			for (WorkCounts = 0; WorkCounts < GameController.GetInstance().WorkSpaceCollection.Count; WorkCounts++) {
				if (MyName == GameController.GetInstance ().WorkSpaceCollection [WorkCounts].gameObject.name.Substring (start - 1, length) && GameController.GetInstance ().WorkSpaceCollection [WorkCounts].CompareTag("workspace")) {
					GameController.GetInstance ().WorkSpaceCollection [WorkCounts].GetComponent<AimCreater> ().WorkSpaceComponent [0].SetActive (true);
					GameController.GetInstance ().WorkSpaceCollectionEx.Add (GameController.GetInstance ().WorkSpaceCollection [WorkCounts]);
				}
			}
		} else {
			GameController.GetInstance().IsRobot = true;
		}
		GameController.GetInstance ().CurrentPlayerTrigger = TempCurrentPlayerTrigger;
		GameController.GetInstance ().CurrentPlayer = TempCurrentPlayer;
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		TweenPosition tween03 = TweenPosition.Begin (BlackLine01, 0.5f, new Vector3 (0, 65.09f, 0));
		TweenPosition tween04 = TweenPosition.Begin (BlackLine02, 0.5f, new Vector3 (0, -65.09f, 0));
		StartCoroutine(WaitRobotExit(2.2f));
	}

	IEnumerator WaitRobotExit(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value); 
		GameController.GetInstance ().FilmMode = false;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
		TextAim.GetComponent<UILabel>().text = " ";
	}
	
	IEnumerator WaitMov(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
			isRobotKeepMove = true;
	}
	
	void WaitNextRobot() //等待的时间,单位秒  
	{  
		if(GameController.GetInstance ().Robot02IsDie == true){
			TextAim.GetComponent<UILabel>().text = "前哨牺牲了……似乎被监工警卫的紫色射线扫描到的机器人如果不在工作状态，就会被击毁。";
			GameController.GetInstance ().Robot02IsDie = false;
			isRobotGoDie = false;
			StartCoroutine(NextRobot(2f));
		}
	}

	IEnumerator NextRobot(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		TextAim.GetComponent<UILabel>().text = "但是只要巧妙掌握时机，便可以通过迅速切换工作状态躲过警卫的扫描。";
		TweenParms Action02 = new TweenParms();
		Action02.Prop("position", new Vector3(Robot03.transform.position[0],Robot03.transform.position[1],-21.3f));
		Action02.Ease (EaseType.EaseOutQuart);
		Action02.OnComplete(RobotSolve);		
		HOTween.To(Camera01.transform,1.5f,Action02);
	}

	void RobotSolve(){
		TextAim.GetComponent<UILabel>().text = "让我们再试一次。沉住气，等待潜入的最佳时机。";
		Robot04Trigger.transform.parent.gameObject.SetActive (false);
		GameController.GetInstance ().CurrentPlayer = Robot03;
		GameController.GetInstance ().CurrentPlayerTrigger = Robot03Trigger;
		MyName = GameController.GetInstance ().CurrentPlayer.name.Substring (start - 1, length);
		for(WorkCounts = 0; WorkCounts < GameController.GetInstance().WorkSpaceCollection.Count; WorkCounts++){
			if(MyName == GameController.GetInstance().WorkSpaceCollection[WorkCounts].gameObject.name.Substring (start - 1, length) && GameController.GetInstance().WorkSpaceCollection[WorkCounts].CompareTag("workspace")){
				GameController.GetInstance().WorkSpaceCollection[WorkCounts].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
				GameController.GetInstance().WorkSpaceCollectionEx.Add(GameController.GetInstance().WorkSpaceCollection[WorkCounts]);
			}
		}
		isRobotSolve = true;
	}

	//Part3-1
	void Anim0201(){
		TextAim.GetComponent<UILabel>().text = "这里似乎没有人，让我们从前面的磁自控货运电梯上去。";
	}

	//Part3-1
	void Anim0202(){
		TextAim.GetComponent<UILabel>().text = "电梯内的移动方式：按住上下左右屏，进行上下左右移动。就像是没有惯性的空间似的，这大概是为了保证货物的安全？";
	}

	//Part4
	void Anim03(){
		GameController.GetInstance ().FilmMode = true;
		GameController.GetInstance ().BallPosition = Pos3.gameObject.transform.position;
		GameController.GetInstance ().Robot01Position = new Vector3(-37.77902f, -2.061617f, 0.3000002f);
		ButtonPause.GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		TextAim.GetComponent<UILabel>().text = "监工警卫似乎没有反间谍扫描功能。如果没办法通过切换工作模式进行欺骗的话，干脆脱离机器人，大大方方地走过去吧。";
		BallRobot.GetComponent<Rigidbody>().Sleep();
		TweenPosition tween01 = TweenPosition.Begin (BlackLine01 , 0.5f , new Vector3(0,48.9f,0));
		TweenPosition tween02 = TweenPosition.Begin (BlackLine02 , 0.5f , new Vector3(0,-48.9f,0));
		Door05.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
		StartCoroutine(WaitNextDoor05(2.5f));
	}

	IEnumerator WaitNextDoor05(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		Door05.SetActive (false);
		BallRobot.GetComponent<Rigidbody> ().WakeUp ();
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		TweenPosition tween03 = TweenPosition.Begin (BlackLine01, 0.5f, new Vector3 (0, 65.09f, 0));
		TweenPosition tween04 = TweenPosition.Begin (BlackLine02, 0.5f, new Vector3 (0, -65.09f, 0));
		StartCoroutine(WaitMissGuard(2.2f));
	}

	IEnumerator WaitMissGuard(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		if (GameController.GetInstance ().CurrentPlayer.tag != "Player") {
			TextAim.GetComponent<UILabel> ().text = "手指向下滑屏，脱离机器人。";
			isOutRobot = true;
			isDownSwiped = true;
		} else {
			StartCoroutine(WaitNextGuard(2.2f));
		}
	}

	void WaitOutRobot(){
		if(isOutRobot == true && GameController.GetInstance().outRobot == true){
			for(WorkCounts = 0; WorkCounts < GameController.GetInstance().WorkSpaceCollection.Count; WorkCounts++){
				if(GameObject.Find ("FollowedObject").GetComponent<PlayerChange> ().CurrentPlayerString == GameController.GetInstance().WorkSpaceCollection[WorkCounts].gameObject.name.Substring (start - 1, length)){
					GameController.GetInstance().WorkSpaceCollection[WorkCounts].GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
				}
			}
			isOutRobot = false;
			DownFingerSwipe.Kill();
			Arrow02.SetActive(false);
			isDownOnce = false;
			BallRobot.SetActive(true);
			BallRobot.transform.position = new Vector3 (GameController.GetInstance().CurrentPlayer.gameObject.transform.position [0], GameController.GetInstance().CurrentPlayer.gameObject.transform.position [1], 0f);
			GameController.GetInstance().IsRobot = false;
			GameController.GetInstance().CurrentPlayer = BallRobot;
			GameController.GetInstance().CurrentPlayerTrigger = BallRobot;
			GameController.GetInstance().BallToRobot = true;
			StartCoroutine(WaitNextGuard(2.2f));
		}
	}

	IEnumerator WaitNextGuard(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		TweenParms Action09 = new TweenParms ();
		Action09.Prop ("position", new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f));
		Action09.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action09);
		TextAim.GetComponent<UILabel>().text = " ";
		StartCoroutine(WaitNextCancel(2.0f));
	}

	IEnumerator WaitNextCancel(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		GameController.GetInstance ().FilmMode = false;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
	}


	//Part5
	void Anim04(){
		GameController.GetInstance ().FilmMode = true;
		ButtonPause.GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		BallRobot.GetComponent<Rigidbody>().Sleep();
		TweenPosition tween01 = TweenPosition.Begin (BlackLine01 , 0.5f , new Vector3(0,48.9f,0));
		TweenPosition tween02 = TweenPosition.Begin (BlackLine02 , 0.5f , new Vector3(0,-48.9f,0));
		Door06.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
		StartCoroutine(WaitNextDoor06(2.5f));
	}
	
	IEnumerator WaitNextDoor06(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		Door06.SetActive (false);
		BallRobot.GetComponent<Rigidbody> ().WakeUp ();
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		TweenPosition tween03 = TweenPosition.Begin (BlackLine01, 0.5f, new Vector3 (0, 65.09f, 0));
		TweenPosition tween04 = TweenPosition.Begin (BlackLine02, 0.5f, new Vector3 (0, -65.09f, 0));
		StartCoroutine(WaitNextGuard02(1.2f));
	}

	IEnumerator WaitNextGuard02(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		TextAim.GetComponent<UILabel>().text = "继续前进！";
		GameController.GetInstance ().FilmMode = false;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
	}

	//Part6
	void Anim05(){
		GameController.GetInstance ().FilmMode = true;
		GameController.GetInstance ().BallPosition = Pos4.gameObject.transform.position;
		ButtonPause.GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		BallRobot.GetComponent<Rigidbody>().Sleep();
		TweenPosition tween01 = TweenPosition.Begin (BlackLine01 , 0.5f , new Vector3(0,48.9f,0));
		TweenPosition tween02 = TweenPosition.Begin (BlackLine02 , 0.5f , new Vector3(0,-48.9f,0));
		Door07.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
		StartCoroutine(WaitNextDoor07(2.5f));
	}
	
	IEnumerator WaitNextDoor07(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		Door07.SetActive (false);
		BallRobot.GetComponent<Rigidbody> ().WakeUp ();
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (GameController.GetInstance().CurrentPlayer.transform.position [0], GameController.GetInstance().CurrentPlayer.transform.position [1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		TweenPosition tween03 = TweenPosition.Begin (BlackLine01, 0.5f, new Vector3 (0, 65.09f, 0));
		TweenPosition tween04 = TweenPosition.Begin (BlackLine02, 0.5f, new Vector3 (0, -65.09f, 0));
		StartCoroutine(WaitNextGuard03(1.2f));
	}

	IEnumerator WaitNextGuard03(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		TextAim.GetComponent<UILabel>().text = "每种机器人有其特定的工作区域。你在操控状态下，只有到达视野里出现的白色瞄准镜标识所在的位置，才能够切换为工作模式。";
		GameController.GetInstance ().FilmMode = false;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
	}

	//Part7
	void Anim06(){
		GameController.GetInstance ().FilmMode = true;
		if(GameController.GetInstance().CurrentPlayer.tag != "Player"){
			BallRobot.SetActive(true);
			BallRobot.transform.position = new Vector3 (GameController.GetInstance().CurrentPlayer.gameObject.transform.position [0], GameController.GetInstance().CurrentPlayer.gameObject.transform.position [1], 0f);
			GameController.GetInstance().CurrentPlayer = BallRobot;
			GameController.GetInstance().CurrentPlayerTrigger = BallRobot;
		}
		TextAim.GetComponent<UILabel>().text = "在深入下一敌方区域前，我们介绍一下鹰眼系统。";
		StartCoroutine(WaitNextDoor08(2f));
	}

	IEnumerator WaitNextDoor08(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		isIntoView = 0;
		GameController.GetInstance ().FilmMode = false;
		BallRobot.SetActive(false);
	}

	void ViewerModeInto(){
		if(isIntoView == 0){
			TextAim.GetComponent<UILabel>().text = "点击此处的鹰眼开关，开启鹰眼。";
			IntoViewTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));;
			isIntoView = 1;
			Circle05.SetActive (true);
			IntoViewTap.Prepend(HOTween.To (Circle05.transform, 1.2f, new TweenParms ().Prop ("localScale", new Vector3(1.2f,1.2f,0f)).Ease (EaseType.EaseInOutQuint)));
			IntoViewTap.Insert (0,HOTween.To (Circle05.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(0.6f,0.6f,0.6f,0f)).Ease (EaseType.EaseInOutQuint)));
			IntoViewTap.Play ();
		}
		if(GameController.GetInstance().intoViewMode == true && isIntoView == 1){
			isIntoView = 2;
			IntoViewTap.Kill();
			Circle05.SetActive(false);
		}
	}

	void ViewerMode(){
		if(isView == 0 && isIntoView == 2){
			TextAim.GetComponent<UILabel>().text = "手指在屏幕上拖动，来切换视野。";
			isView = 1;
			Arrow03.SetActive (true);
			Arrow04.SetActive (true);
			ViewTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			ViewTap.Prepend(HOTween.To (Arrow03.GetComponent<UISprite>(), 0.01f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,1f)).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Insert(0.01f,HOTween.To (Arrow03.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,0f)).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Insert(0.01f,HOTween.To (Arrow03.transform, 1.2f, new TweenParms ().Prop ("position", new Vector3(Arrow03.transform.position[0]-48f, Arrow03.transform.position[1], Arrow03.transform.position[2])).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Insert(1.21f,HOTween.To (Arrow04.GetComponent<UISprite>(), 0.01f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,1f)).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Insert(1.22f,HOTween.To (Arrow04.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(1f,1f,1f,0f)).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Insert(1.22f,HOTween.To (Arrow04.transform, 1.2f, new TweenParms ().Prop ("position", new Vector3(Arrow03.transform.position[0]+48f, Arrow04.transform.position[1], Arrow04.transform.position[2])).Ease (EaseType.EaseInOutQuint)));
			ViewTap.Play ();
			StartCoroutine(OutViewer(5f));
		}
	}

	IEnumerator OutViewer(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		isView = 2;
		ViewTap.Kill();
		Arrow03.SetActive (false);
		Arrow04.SetActive (false);
	}

	void ViewerModeOut(){
		if(isOutView == 0 && isView == 2){
			TextAim.GetComponent<UILabel>().text = "点击此处的鹰眼开关，关闭鹰眼。";
			OutViewTap = new Sequence (new SequenceParms().Loops(-1,LoopType.Restart));
			isOutView = 1;
			Circle05.SetActive (true);
			OutViewTap.Prepend(HOTween.To (Circle05.transform, 1.2f, new TweenParms ().Prop ("localScale", new Vector3(1.2f,1.2f,0f)).Ease (EaseType.EaseInOutQuint)));
			OutViewTap.Insert (0,HOTween.To (Circle05.GetComponent<UISprite>(), 1.2f, new TweenParms ().Prop ("color", new Color(0.6f,0.6f,0.6f,0f)).Ease (EaseType.EaseInOutQuint)));
			OutViewTap.Play ();
		}
		if(GameController.GetInstance().outViewMode == true && isOutView == 1){
			isOutView = 2;
			OutViewTap.Kill();
			Circle05.SetActive(false);
			StartCoroutine(WaitFinal(2f));
		}
	}

	IEnumerator WaitFinal(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		isFinalRush = true;
		BallRobot.SetActive(true);
		Door08.GetComponent<tk2dSpriteAnimator> ().Play("DoorOpen");
		StartCoroutine(Final(2f));
	}

	void FinalRush(){
		if(isFinalRush == true){
			BallRobot.GetComponent<Rigidbody> ().AddForce (GameController.GetInstance().MovePower, 0, 0);
		}
	}

	IEnumerator Final(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds(value);
		Door08.SetActive (false);
		TweenParms GameWin = new TweenParms ();
		//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
		GameWin.Prop ("color", new Color (1, 1, 1, 1));
		//回调函数GameOverScene
		GameWin.OnComplete (GameWinScene);
		HOTween.To (GameObject.Find ("over").gameObject.GetComponent<tk2dSprite> (), 0.5f, GameWin);
	}

	private void GameWinScene(){
		Application.LoadLevel ("DemoWin");
	}

	void Anim07(){
		GameController.GetInstance ().BallPosition = Pos2.gameObject.transform.position;
		GameController.GetInstance ().Robot01Position = Pos2.gameObject.transform.position;
	}
}
