using System.Collections;
using UnityEngine;
using System.Collections.Generic;

	public class ButtonSelectControl : MonoBehaviour{
		public int i;
    	// Use this for initialization
    	private void Start(){
    	    GetComponent<UIButton>().isEnabled = false;
			if(Global.GetInstance().SelectedSave == 1){
				GameController.GetInstance().Levels = ES2.LoadList<Level>("player01.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 2){
				GameController.GetInstance().Levels = ES2.LoadList<Level>("player02.dat?tag=LevelInfo");
			}else if(Global.GetInstance().SelectedSave == 3){
				GameController.GetInstance().Levels = ES2.LoadList<Level>("player03.dat?tag=LevelInfo");
			}
			for(i=0;i < GameController.GetInstance().Levels.Count; i++){
				if(GameController.GetInstance().Levels[i].LevelNum.ToString() == gameObject.name && GameController.GetInstance().Levels[i].LevelLock == false){
					if(GameController.GetInstance().Levels[i].isCurrent == false){
						GetComponent<UIButton>().isEnabled = true;
					}else{
						Invoke("Temp",1);
					}
				}
			}
    	}

    	// Update is called once per frame
    private void Update(){

	}

	public void Temp(){
		gameObject.transform.parent.gameObject.GetComponent<AnimationForActivate>().ActivateAnimation();
	}
	}