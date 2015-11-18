using UnityEngine;
using System.Collections;

public class ButtonExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		Application.Quit();//退出游戏
	}
}
