using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class PlayerGameOver : MonoBehaviour {
	public GameObject Camera01;
	public GameObject TextAim;
	public GameObject ButtonPause;
	public GameObject ButtonViewer;
	public GameObject Robot01;
	private GameObject GuardBody;
	private bool JudgeOnce = true;//令触发结算只结算一次
	private List<GameObject> LightComponent = new List<GameObject>();//警卫组件列表
	//小球碎裂动画添加
	public GameObject BallPlayerDes;
	GameObject Pi;

	void Awake(){
		foreach (Transform child in GameObject.Find("WorkSpace").transform) {
			GameController.GetInstance().WorkSpaceCollection.Add (child.gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}

	//用于小球作为操作对象时遇到类型2警卫的GameOver结算
	void OnTriggerStay(Collider IsRobotWork){
		//如果遇到的警卫为类型2且当前操作对象为小球
		if (IsRobotWork.CompareTag("guard-2b") && GameController.GetInstance().IsRobot == false) {
			if(JudgeOnce == true){
				foreach (Transform child in IsRobotWork.transform.parent.transform.parent.transform) {
					//获得警卫的组件
					LightComponent.Add (child.gameObject);
				}
				JudgeOnce = false;
				//新建警卫的HOTween补间动画
				Sequence Guard02Alert = new Sequence (new SequenceParms().Loops(10,LoopType.Restart));
				//警卫颜色闪烁
				Guard02Alert.Prepend(HOTween.To (IsRobotWork.gameObject.GetComponent<tk2dSprite> (), 0.08f,new TweenParms().Prop("color", new Color (1f, 1f, 1f, 0.5f))));
				Guard02Alert.Append(HOTween.To (IsRobotWork.gameObject.GetComponent<tk2dSprite> (), 0.08f,new TweenParms().Prop("color", new Color (1f, 1f, 1f, 1f))));
				Guard02Alert.Play();
				//计算粒子子弹发射角度
				float ShootAngle01 = Vector3.Angle(
					new Vector3(100f,0f,0f),
					transform.position*100.0f-LightComponent[1].transform.position*100.0f)
					*-Mathf.Sign(
					Vector3.Cross(
					new Vector3(100f,0f,0f),transform.position*100.0f-LightComponent[1].transform.position*100.0f)[2]);
				print(ShootAngle01);
				LightComponent[1].transform.rotation = Quaternion.Euler(ShootAngle01,90,0);
				LightComponent[1].GetComponent<ParticleSystem>().Play();
				if(Application.loadedLevelName != "DemoTech"){
					gameObject.GetComponent<Rigidbody>().Sleep();
					GetComponent<PlayerControl>().isAvail = false;
					//新建整体的HOTween补间动画
					TweenParms Gameover = new TweenParms();
					//颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
					Gameover.Prop("color",new Color(1,1,1,1));
					//回调函数GameOverScene
					Gameover.OnComplete(GameOverScene);
					HOTween.To(GameObject.Find("over").gameObject.GetComponent<tk2dSprite>(), 2f, Gameover);
				}else{
					if(gameObject.name == "BallRobot"){
						JudgeOnce = true;
						gameObject.GetComponent<Rigidbody>().Sleep();
						GetComponent<PlayerControl>().isAvail = false;
						GameController.GetInstance ().FilmMode = true;
						ButtonPause.GetComponent<UIButton> ().isEnabled = false;
						ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
						TextAim.GetComponent<UILabel>().text = "放轻松，我们再试一次。";
						TweenParms Action03 = new TweenParms ();
						Action03.Prop ("position", new Vector3 (GameController.GetInstance().BallPosition [0], GameController.GetInstance().BallPosition [1], -21.3f));
						Action03.Ease (EaseType.EaseOutQuart);		
						HOTween.To (Camera01.transform, 2.0f, Action03);
						gameObject.transform.position = GameController.GetInstance().BallPosition;
						Robot01.transform.position = GameController.GetInstance().Robot01Position;
						StartCoroutine (Miss (1.5f));
					}
				}
			}
		}
        //如果遇到了警卫3并且还被控制状态
        if (IsRobotWork.CompareTag("guard-3") && GameController.GetInstance().IsRobot == false)
        {
            if (JudgeOnce == true)
            {
                foreach (Transform child in IsRobotWork.transform.parent.transform.parent.transform)
                {
                    //获得警卫的组件
                    LightComponent.Add(child.gameObject);
                }
                JudgeOnce = false;
                //新建警卫的HOTween补间动画
                Sequence Guard02Alert = new Sequence(new SequenceParms().Loops(10, LoopType.Restart));
                //警卫颜色闪烁
                Guard02Alert.Prepend(HOTween.To(IsRobotWork.gameObject.GetComponent<tk2dSprite>(), 0.08f, new TweenParms().Prop("color", new Color(1f, 1f, 1f, 0.5f))));
                Guard02Alert.Append(HOTween.To(IsRobotWork.gameObject.GetComponent<tk2dSprite>(), 0.08f, new TweenParms().Prop("color", new Color(1f, 1f, 1f, 1f))));
                Guard02Alert.Play();
                //计算粒子子弹发射角度
                float ShootAngle01 = Vector3.Angle(
                    new Vector3(100f, 0f, 0f),
                    transform.position * 100.0f - LightComponent[1].transform.position * 100.0f)
                    * -Mathf.Sign(
                    Vector3.Cross(
                    new Vector3(100f, 0f, 0f), transform.position * 100.0f - LightComponent[1].transform.position * 100.0f)[2]);
				print(ShootAngle01);
				print(LightComponent[1].transform.position[0] + "and" +LightComponent[1].transform.position[1]);
				print(LightComponent[1].transform.parent.name);
                LightComponent[1].transform.rotation = Quaternion.Euler(ShootAngle01, 90, 0);
                LightComponent[1].GetComponent<ParticleSystem>().Play();
                if (Application.loadedLevelName != "DemoTech")
                {
                    GetComponent<PlayerControl>().isAvail = false;
                    //新建整体的HOTween补间动画
                    TweenParms Gameover = new TweenParms();
                    //颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
                    Gameover.Prop("color", new Color(1, 1, 1, 1));
                    //回调函数GameOverScene
                    Gameover.OnComplete(GameOverScene);
                    HOTween.To(GameObject.Find("over").gameObject.GetComponent<tk2dSprite>(), 2f, Gameover);
                }
                else
                {
                    if (gameObject.name == "BallRobot")
                    {
                        JudgeOnce = true;
                        gameObject.GetComponent<Rigidbody>().Sleep();
                        GetComponent<PlayerControl>().isAvail = false;
                        GameController.GetInstance().FilmMode = true;
                        ButtonPause.GetComponent<UIButton>().isEnabled = false;
                        ButtonViewer.GetComponent<UIButton>().isEnabled = false;
                        TextAim.GetComponent<UILabel>().text = "放轻松，我们再试一次。";
                        TweenParms Action03 = new TweenParms();
                        Action03.Prop("position", new Vector3(GameController.GetInstance().BallPosition[0], GameController.GetInstance().BallPosition[1], -21.3f));
                        Action03.Ease(EaseType.EaseOutQuart);
                        HOTween.To(Camera01.transform, 2.0f, Action03);
                        gameObject.transform.position = GameController.GetInstance().BallPosition;
                        Robot01.transform.position = GameController.GetInstance().Robot01Position;
                        StartCoroutine(Miss(1.5f));
                    }
                }
            }
        }
        //如果遇到了二号电梯并且还被控制状态
        if (IsRobotWork.CompareTag("elevator2") && GameController.GetInstance().IsRobot == false)
        {
            if (JudgeOnce == true)
            {
                if (Application.loadedLevelName != "DemoTech")
                {
					if(GameController.GetInstance().ShootOnce == true){
						GameController.GetInstance().ShootOnce = false;
						Pi = Instantiate(BallPlayerDes, transform.position, Quaternion.identity) as GameObject;                     
						gameObject.GetComponent<tk2dSprite> ().color = new Color (1,1,1,0);
						gameObject.GetComponent<Rigidbody>().Sleep();
						GameObject.Find("Camera01").transform.position = new Vector3(Pi.transform.position[0],Pi.transform.position[1],-23.1f);
						StartCoroutine(WaitDie(2.0f));
					}
                    GetComponent<PlayerControl>().isAvail = false;
                    //新建整体的HOTween补间动画
                    TweenParms Gameover = new TweenParms();
                    //颜色Aplaha通道渐变至255（即屏幕渐渐变黑）
                    Gameover.Prop("color", new Color(1, 1, 1, 1));
                    //回调函数GameOverScene
                    Gameover.OnComplete(GameOverScene);
                    HOTween.To(GameObject.Find("over").gameObject.GetComponent<tk2dSprite>(), 2f, Gameover);

                }
                else
                {
                    if (gameObject.name == "BallRobot")
                    {

						JudgeOnce = true;
                        gameObject.GetComponent<Rigidbody>().Sleep();
                        GetComponent<PlayerControl>().isAvail = false;
                        GameController.GetInstance().FilmMode = true;
                        ButtonPause.GetComponent<UIButton>().isEnabled = false;
                        ButtonViewer.GetComponent<UIButton>().isEnabled = false;
                        TextAim.GetComponent<UILabel>().text = "放轻松，我们再试一次。";
                        TweenParms Action03 = new TweenParms();
                        Action03.Prop("position", new Vector3(GameController.GetInstance().BallPosition[0], GameController.GetInstance().BallPosition[1], -21.3f));
                        Action03.Ease(EaseType.EaseOutQuart);
                        HOTween.To(Camera01.transform, 2.0f, Action03);
                        gameObject.transform.position = GameController.GetInstance().BallPosition;
                        Robot01.transform.position = GameController.GetInstance().Robot01Position;
                        StartCoroutine(Miss(1.5f));
                    }
                }
            }
        }
	}

	IEnumerator Miss(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		TweenParms Action03 = new TweenParms ();
		Action03.Prop ("position", new Vector3 (gameObject.transform.position[0], gameObject.transform.position[1], -21.3f));
		Action03.Ease (EaseType.EaseOutQuart);		
		HOTween.To (Camera01.transform, 2.0f, Action03);
		StartCoroutine(waitRe(2.0f));
	}

	IEnumerator waitRe(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value);
		GameController.GetInstance ().FilmMode = false;
		GetComponent<PlayerControl>().isAvail = true;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
		TextAim.GetComponent<UILabel>().text = " ";
		gameObject.GetComponent<Rigidbody> ().WakeUp ();
	}

	private void GameOverScene(){
		//场景时间冻结（初始默认为1）
		Time.timeScale = 0;
		Application.LoadLevel ("DemoOver");
		JudgeOnce = true;
	}

	IEnumerator WaitDie(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value); 
		Destroy (Pi);
		gameObject.SetActive (false);

	}
}
