using UnityEngine;
using System.Collections;
using System;

public class ShowFrameRate : MonoBehaviour {	
	public float UpdateInterval = 0.5F;	
	private float LastInterval;	
	private int Frames = 0;	
	public int Fps;
	
	void Start() 
	{
		//Application.targetFrameRate=60;		
		LastInterval = Time.realtimeSinceStartup;		
		Frames = 0;
	}
	
	void OnGUI() 
	{
		GUI.Label(new Rect(0, 200, 200, 200), "FPS:" + Fps);
	}
	
	void Update() 
	{
		++Frames;		
		if (Time.realtimeSinceStartup > LastInterval + UpdateInterval) 
		{
			Fps = Convert.ToInt32(Math.Round( (Frames / (Time.realtimeSinceStartup - LastInterval)),0));			
			Frames = 0;			
			LastInterval = Time.realtimeSinceStartup;
		}
	}
}