using UnityEngine;
using System.Collections;

public class ButtonRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		//重新开始本关
		Time.timeScale = 1; 
		Application.LoadLevel("DemoLoading");
	}
}
