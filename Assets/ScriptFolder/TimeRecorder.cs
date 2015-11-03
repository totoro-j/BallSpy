using UnityEngine;
using System.Collections;

public class TimeRecorder : MonoBehaviour {
	int minutes,seconds,microseconds;
	// Use this for initialization
	void Start () {
	
	}
		
	// Update is called once per frame
	void Update () {	
		if (GameController.GetInstance ().CameraInitializationState == true) {
			GameController.GetInstance().TimeRecorder += Time.deltaTime;		
			minutes = ((int)GameController.GetInstance().TimeRecorder)/60;
			seconds = ((int)GameController.GetInstance().TimeRecorder)-(((int)GameController.GetInstance().TimeRecorder)/60)*60;
			microseconds = (int)(GameController.GetInstance().TimeRecorder*100)- (int)(GameController.GetInstance().TimeRecorder*100)/100*100;			
			if( minutes == 0 ){	
				if(seconds == 0){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = "00:00:00";
					}
					
					if(microseconds > 0 && microseconds < 10)					{
						gameObject.GetComponent<UILabel>().text = "00:00:0" + microseconds;					
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = "00:00:" + microseconds;
					}
				}
				
				if(seconds > 0 && seconds < 10){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = "00:0"+ seconds+":00";					
					}
					
					if(microseconds > 0 && microseconds < 10){
						gameObject.GetComponent<UILabel>().text = "00:0"+ seconds+":0"+microseconds;					
					}
					
					if(microseconds >9){
						gameObject.GetComponent<UILabel>().text = "00:0"+ seconds+":"+microseconds;					
					}
				}
				
				if(seconds > 9 && seconds < 60){
					if(microseconds==0){
						gameObject.GetComponent<UILabel>().text = "00:"+seconds+":00";
					}
					
					if(microseconds > 0 && microseconds < 10){
						gameObject.GetComponent<UILabel>().text = "00:"+ seconds+":0"+microseconds;			
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = "00:"+ seconds+":"+microseconds;
					}				
				}
			}
			
			if(minutes > 0 && minutes <10){
				if(seconds == 0){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+ ":00:00";
					}
					
					if(microseconds>0 && microseconds< 10)					{
						gameObject.GetComponent<UILabel>().text = "0"+ minutes +":00:0" + microseconds;		
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+ ":00:"+microseconds;
					}
				}
				
				if(seconds > 0 && seconds < 10){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":0"+ seconds+":00";					
					}
					
					if(microseconds > 0 && microseconds < 10){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":0"+ seconds+":0"+microseconds;				
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":0"+ seconds+":"+microseconds;					
					}
				}
				
				if(seconds > 9 && seconds < 60){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":"+seconds+":00";
					}
					
					if(microseconds>0 && microseconds< 10){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":"+seconds+":0"+microseconds;					
					}
					
					if( microseconds > 9){
						gameObject.GetComponent<UILabel>().text = "0"+minutes+":"+seconds+":"+microseconds;					
					}
				}			
			}
			
			if(minutes > 9){
				if(seconds == 0){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = minutes+ ":00:00";
					}
					
					if(microseconds>0 && microseconds< 10){
						gameObject.GetComponent<UILabel>().text = minutes +":00:0" + microseconds;		
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = minutes + ":00:" + microseconds;
					}
				}
				
				if(seconds > 0 && seconds < 10){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = minutes + ":0" + seconds + ":00";					
					}
					
					if(microseconds > 0 && microseconds < 10){
						gameObject.GetComponent<UILabel>().text = minutes + ":0" + seconds + ":0"+microseconds;					
					}
					
					if(microseconds > 9){
						gameObject.GetComponent<UILabel>().text = minutes + ":0" + seconds + ":"+microseconds;					
					}
				}
				
				if(seconds > 9 && seconds < 60){
					if(microseconds == 0){
						gameObject.GetComponent<UILabel>().text = minutes+":"+seconds+":00";
					}
					
					if(microseconds>0 && microseconds< 10){
						gameObject.GetComponent<UILabel>().text = minutes+":"+seconds+":0"+microseconds;					
					}
					
					if( microseconds > 9){
						gameObject.GetComponent<UILabel>().text = minutes+":"+seconds+":"+microseconds;					
					}
				}
			}		
		}
	}
}
