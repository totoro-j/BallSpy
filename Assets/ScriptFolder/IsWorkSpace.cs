using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class IsWorkSpace : MonoBehaviour {
	public bool isworkspace = false;//用于判断机器人是否在对应工作台区域
	public string CurrentRobotName;//当前玩家机器人名称
	public string CurrentWorkSpace;//当前玩家机器人所在工作台名称
	public string ThisRobotName;//当前其他机器人名称
	int start=1,length=8,lengthType=10;//规定字符串截取的方法以获取机器人和工作台的前缀
	// Use this for initialization
	void Start () {
		//获取当前机器人的名称前缀
		CurrentRobotName = gameObject.name.Substring (start - 1, length);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	void OnTriggerStay(Collider IsWorkSpace){
		//如果在工作台附近
		if (IsWorkSpace.tag == "workspace") {
			if(gameObject.GetComponent<RobotGameOver>().isAvail == true){
				//获取工作台名称前缀
				CurrentWorkSpace = IsWorkSpace.name.Substring (start - 1, length);
				GetComponent<WorkSpaceController> ().CurrentWorkSpaceType = IsWorkSpace.name.Substring (start - 1, lengthType);
				GetComponent<WorkSpaceController> ().MyNameIsWorkSpace = IsWorkSpace.gameObject;
				//如果当前操作对象为机器人且机器人和工作台前缀相同
				if (CurrentRobotName == CurrentWorkSpace) {
					//机器人就处在对应工作台区域
					if(GetComponent<RobotTrigger>().IsActive == false){
						GetComponent<RobotTrigger>().IsActive = true;
					}
					isworkspace = true;
					if(IsWorkSpace.gameObject.GetComponent<AimCreater>() != null){
						IsWorkSpace.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
					}else if(IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>() != null){
						IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (false);
					}
					IsWorkSpace.tag = "Onlyworkspace";
				}
			}
		}

		//用于解决多个机器人在一个工作台时隔离其他机器人
		if(IsWorkSpace.tag == "workspace" || IsWorkSpace.tag == "Onlyworkspace" ){
			if(gameObject.GetComponent<RobotGameOver>().isAvail == false){
				isworkspace = false;
				if(IsWorkSpace.gameObject.GetComponent<AimCreater>() != null){
					IsWorkSpace.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
				}else if(IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>() != null){
					IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
				}
				IsWorkSpace.tag = "workspace";
			}
			if(IsWorkSpace.GetComponent<MineralAnimation>() != null){
				if(IsWorkSpace.GetComponent<MineralAnimation>().DestroyAlert == true){
					isworkspace = false;
					GetComponent<RobotGameOver> ().isWork = false;
					transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Stop ();
					GameController.GetInstance().intoWork = false;
					GameController.GetInstance().outWork = false;
					CurrentWorkSpace = null;
					GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
					GetComponent<RobotTrigger>().isMove = 1;
				}
			}else if(IsWorkSpace.transform.parent.gameObject.GetComponent<MineralAnimation>() != null){
				if(IsWorkSpace.transform.parent.gameObject.GetComponent<MineralAnimation>().DestroyAlert == true){
					isworkspace = false;
					GetComponent<RobotGameOver> ().isWork = false;
					transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Stop ();
					GameController.GetInstance().intoWork = false;
					GameController.GetInstance().outWork = false;
					GetComponent<WorkSpaceController> ().isWorkSpacePlay = false;
					CurrentWorkSpace = null;
					GetComponent<RobotTrigger>().isMove = 1;
				}
			}
		}
	}

	void OnTriggerExit(Collider IsWorkSpace){
		if (IsWorkSpace.tag == "workspace") {
			//离开工作台区域即false
			isworkspace = false;
		}else if(IsWorkSpace.tag == "Onlyworkspace"){
			if(IsWorkSpace.gameObject.GetComponent<AimCreater>() != null){
				IsWorkSpace.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
			}else if(IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>() != null){
				IsWorkSpace.gameObject.transform.parent.gameObject.GetComponent<AimCreater>().WorkSpaceComponent [0].SetActive (true);
			}
			isworkspace = false;
			IsWorkSpace.tag = "workspace";
		}
	}
}
