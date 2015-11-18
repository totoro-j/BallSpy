using UnityEngine;
using System.Collections;

public class ButtonContiune : MonoBehaviour {
	public GameObject container;
	public GameObject ButtonViewer;
	public GameObject ButtonPause;
	public GameObject ButtonRestart;
	public GameObject ButtonMainMenu;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void OnClick () {
		//继续功能按钮
		Time.timeScale = 1;
		ButtonRestart.GetComponent<UIButton> ().isEnabled = false;
		ButtonMainMenu.GetComponent<UIButton> ().isEnabled = false;
		GetComponent<UIButton> ().isEnabled = false;
		TweenPosition tween = TweenPosition.Begin (container , 0.5f , new Vector3(0,110f,0));
		tween.method = UITweener.Method.Linear;
		ButtonPause.GetComponent<UIButton> ().isEnabled = true;
		ButtonViewer.GetComponent<UIButton> ().isEnabled = true;
	}
}
