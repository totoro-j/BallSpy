using UnityEngine;
using System.Collections;

public class ButtonC0101 : MonoBehaviour {
	public string ThisScreen;
	// Use this for initialization
	void Start () {

	}
	
	void OnClick () {
		Global.GetInstance ().loadName = ThisScreen; //这个之后作为点击加载关卡的统一脚本，脚本名字以后改掉
		Application.LoadLevel("DemoLoading");
	}
}
