using UnityEngine;
using System.Collections;

public class Global {
	public string loadName = "DemoTech";//负责记录场景名称
	//音频播放参数
	public bool MusicOff = false;//音乐默认开启
	//存档读取参数
	public int SelectedSave = 0;

	public int CurrentStayLevel = 0;

	private static Global instance;

	public static Global GetInstance()  
	{  
		if (instance == null) {
			instance = new Global ();  
		}

		return instance;  
	}  
}