using UnityEngine;
using System.Collections;

public class ButtonMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Global.GetInstance ().MusicOff == true){
			if(gameObject.name == "Button - Music"){
				gameObject.GetComponent<TweenScale>().from = new Vector3(1,1,1);
				gameObject.GetComponent<TweenScale>().to = new Vector3(0,0,1);
			}else {
				gameObject.GetComponent<TweenScale>().from = new Vector3(0,0,1);
				gameObject.GetComponent<TweenScale>().to = new Vector3(1,1,1);
			}
		}
	}
	
	void OnClick () {
		if(Global.GetInstance ().MusicOff == false){
			//
			Global.GetInstance ().MusicOff = true;
			//GetComponent<UIButton>().normalSprite = "MusicOff";
		}else if(Global.GetInstance ().MusicOff == true){
			//
			Global.GetInstance ().MusicOff = false;
			//GetComponent<UIButton>().normalSprite = "MusicOn";
		}
	}
}
