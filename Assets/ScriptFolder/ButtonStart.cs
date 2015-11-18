using UnityEngine;
using System.Collections;

public class ButtonStart : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnClick () {
		//目前是切换到选关界面
		Application.LoadLevel("DemoSave");  
	}
}
