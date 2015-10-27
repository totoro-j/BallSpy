using UnityEngine;
using System.Collections;

public class ButtonPause : MonoBehaviour {
	public GameObject container;
	public GameObject ButtonViewer;
	public GameObject ButtonRestart;
	public GameObject ButtonMainMenu;
	public GameObject ButtonContinue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnClick () {
		//暂停功能
		Time.timeScale = 0;
		GetComponent<UIButton> ().isEnabled = false;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = false;
		ButtonRestart.GetComponent<UIButton> ().isEnabled = true;
		ButtonMainMenu.GetComponent<UIButton> ().isEnabled = true;
		ButtonContinue.GetComponent<UIButton> ().isEnabled = true;
		TweenPosition tween = TweenPosition.Begin (container , 1 , Vector3.zero);
		tween.delay = 0.5f;
		tween.method = UITweener.Method.BounceIn;
	}
}
