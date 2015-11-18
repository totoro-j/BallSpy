using UnityEngine;
using System.Collections;

public class ButtonViewer : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		if(GameController.GetInstance().intoViewMode == false){
			//进入观察者模式
			GameController.GetInstance().intoViewMode = true;
			GameController.GetInstance().outViewMode = false;
			GetComponent<UIButton>().normalSprite = "closeeyes";
		}else if(GameController.GetInstance().intoViewMode == true){
			//退出观察者模式
			GameController.GetInstance().outViewMode = true;
			GameController.GetInstance().intoViewMode = false;
			GetComponent<UIButton>().normalSprite = "openeyes";
		}
	}
}
