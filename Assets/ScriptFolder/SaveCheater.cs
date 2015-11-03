using UnityEngine;
using System.Collections;

public class SaveCheater : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Cheater () {
		GameController.GetInstance ().CurrentLevelNum = 4;
		GameController.GetInstance ().CurrentLevelSceneNum = 4;
		GameController.GetInstance ().Levels [0].isCurrent = false;
		if(GameController.GetInstance ().Levels.Count < 2){
			GameController.GetInstance().Levels.Add(
				new Level{
				LevelNum = 2,
				LevelScene = 1,
				LevelSceneNum = 2,
				LevelLock = false,
				isCurrent = false,
				LevelTime = 999999,
				LevelStars = 0
			}
			);
		}

		if(GameController.GetInstance ().Levels.Count < 3){
			GameController.GetInstance ().Levels[1].isCurrent = false;
			GameController.GetInstance().Levels.Add(
				new Level{
				LevelNum = 3,
				LevelScene = 1,
				LevelSceneNum = 3,
				LevelLock = false,
				isCurrent = false,
				LevelTime = 999999,
				LevelStars = 0
			}
			);
		}

		if(GameController.GetInstance ().Levels.Count < 4){
			GameController.GetInstance ().Levels[2].isCurrent = false;
			GameController.GetInstance().Levels.Add(
				new Level{
				LevelNum = 4,
				LevelScene = 1,
				LevelSceneNum = 4,
				LevelLock = false,
				isCurrent = false,
				LevelTime = 999999,
				LevelStars = 0
			}
			);
		}
		if(GameController.GetInstance ().Levels.Count < 5){
			GameController.GetInstance ().Levels[2].isCurrent = false;
			GameController.GetInstance().Levels.Add(
				new Level{
				LevelNum = 5,
				LevelScene = 1,
				LevelSceneNum = 5,
				LevelLock = false,
				isCurrent = true,
				LevelTime = 999999,
				LevelStars = 0
			}
			);
		}
		if(Global.GetInstance().SelectedSave == 1 && ES2.Exists ("player01.dat")){
			ES2.Save(4, "player01.dat?tag=CurrentLevelNum");
			ES2.Save(1, "player01.dat?tag=CurrentLevelScene");
			ES2.Save(4, "player01.dat?tag=CurrentLevelSceneNum");
			ES2.Save(GameController.GetInstance().Levels, "player01.dat?tag=LevelInfo");
		}else if(Global.GetInstance().SelectedSave == 2 && ES2.Exists ("player02.dat")){
			ES2.Save(4, "player02.dat?tag=CurrentLevelNum");
			ES2.Save(1, "player02.dat?tag=CurrentLevelScene");
			ES2.Save(4, "player02.dat?tag=CurrentLevelSceneNum");
			ES2.Save(GameController.GetInstance().Levels, "player02.dat?tag=LevelInfo");
		}else if(Global.GetInstance().SelectedSave == 3 && ES2.Exists ("player03.dat")){
			ES2.Save(4, "player03.dat?tag=CurrentLevelNum");
			ES2.Save(1, "player03.dat?tag=CurrentLevelScene");
			ES2.Save(4, "player03.dat?tag=CurrentLevelSceneNum");
			ES2.Save(GameController.GetInstance().Levels, "player03.dat?tag=LevelInfo");
		}
		gameObject.GetComponent<UILabel> ().text = "您已成功获取作弊存档：）"+System.Environment.NewLine+"立即重新读档吧";
	}
}
