using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonSelectSave : MonoBehaviour {
	public ArrayList LevelDetail;
	public List<Level> LevelInfo = new List<Level>();

	// Use this for initialization
	void Start () {
		LevelInfo.Add (
			/*Level.Create (
			LevelNum: 1,
			LevelScene: 1,
			LevelSceneNum : 1,
			LevelLock: false,
			isCurrent: true,
			LevelTime: 0,
			LevelStars: 0
			)*/
			new Level{
				LevelNum = 1,
				LevelScene = 1,
				LevelSceneNum = 1,
				LevelLock = false,
				isCurrent = true,
				LevelTime = 0,
				LevelStars = 0
			}
		);
	}
	
	void OnClick () {
		if(gameObject.name == "save_click_01"){
			if(!ES2.Exists("player01.dat")){
				ES2.Save(1, "player01.dat?tag=CurrentLevelNum");
				ES2.Save(1, "player01.dat?tag=CurrentLevelScene");
				ES2.Save(1, "player01.dat?tag=CurrentLevelSceneNum");
			//	ES2.Save(false, "player01.dat?tag=CurrentLevelUnlock");
				ES2.Save(LevelInfo, "player01.dat?tag=LevelInfo");
				Global.GetInstance ().SelectedSave = 1;
			}else{
				Global.GetInstance ().SelectedSave = 1;
			}
		}
		if(gameObject.name == "save_click_02"){
			if(!ES2.Exists("player02.dat")){
				ES2.Save(1, "player02.dat?tag=CurrentLevelNum");
				ES2.Save(1, "player02.dat?tag=CurrentLevelScene");
				ES2.Save(1, "player02.dat?tag=CurrentLevelSceneNum");
			//	ES2.Save(false, "player01.dat?tag=CurrentLevelUnlock");
				ES2.Save(LevelInfo, "player02.dat?tag=LevelInfo");
				Global.GetInstance ().SelectedSave = 2;
			}else{
				Global.GetInstance ().SelectedSave = 2;
			}
		}
		if(gameObject.name == "save_click_03"){
			if(!ES2.Exists("player03.dat")){
				ES2.Save(1, "player03.dat?tag=CurrentLevelNum");
				ES2.Save(1, "player03.dat?tag=CurrentLevelScene");
				ES2.Save(1, "player03.dat?tag=CurrentLevelSceneNum");
			//	ES2.Save(false, "player01.dat?tag=CurrentLevelUnlock");
				ES2.Save(LevelInfo, "player03.dat?tag=LevelInfo");
				Global.GetInstance ().SelectedSave = 3;
			}else{
				Global.GetInstance ().SelectedSave = 3;
			}
		}
		Application.LoadLevel("DemoSelect01");
	}
}
