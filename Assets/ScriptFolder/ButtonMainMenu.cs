using UnityEngine;
using System.Collections;

public class ButtonMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		Time.timeScale = 1;
		Application.LoadLevel ("DemoStart");//回到主菜单
	}
}
