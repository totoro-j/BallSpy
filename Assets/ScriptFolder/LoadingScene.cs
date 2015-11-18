using UnityEngine;
using System.Collections;

public class LoadingScene : MonoBehaviour {
	public AsyncOperation async;
	public GameObject TextAim;
	public GameObject Robot01;
	public GameObject Robot01_body;
	public GameObject Label01;
	public GameObject guard1;
	public GameObject workspace;
	public GameObject BallRobot;
	public GameObject guard3;
	bool isAsync = false;
	// Use this for initialization
	void Start () {
		/*if (Global.GetInstance ().loadName == "Screen0101" && Application.loadedLevelName == "DemoLoading") {
			BallRobot.SetActive(false);
			guard3.SetActive(false);
		}else if(Global.GetInstance ().loadName == "Screen0103" && Application.loadedLevelName == "DemoLoading"){
			guard1.SetActive(false);
		}else {
			Robot01.SetActive (false);
			Label01.SetActive (false);
			guard1.SetActive (false);
			workspace.SetActive (false);
			BallRobot.SetActive(false);
			guard3.SetActive(false);
		}*/
		Invoke("Temp",2);
	}

	void FixedUpdate () {
		//神他妈加载进度到0.9就不动了……isDone参数无效……
		if(isAsync == true){
			if(async.progress >= 0.9f){
				TextAim.GetComponent<UILabel>().text = "点击屏幕开始";
				if(Input.GetMouseButtonDown(0)){
					/*if(Global.GetInstance ().loadName == "Screen0101"){
						//杀掉hotween序列动画（遇到过的bug）
						Robot01_body.gameObject.GetComponent<RobotAnimLoad>().G_01.Kill();
					}*/
					isAsync = false;
					async.allowSceneActivation = true;//启用协程加载完自动跳转关卡
				}
			}
		}
	}

	IEnumerator loadScene()  
	{  
		isAsync = true;
		async = Application.LoadLevelAsync(Global.GetInstance().loadName);
		async.allowSceneActivation = false;//禁止协程加载完自动跳转关卡
		yield return async;
	}

	public void Temp(){
		StartCoroutine(loadScene());//开始协程加载
	}
}