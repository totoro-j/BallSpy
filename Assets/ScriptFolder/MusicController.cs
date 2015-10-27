using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Global.GetInstance().MusicOff == false && gameObject.GetComponent<AudioSource>().isPlaying == false){
			gameObject.GetComponent<AudioSource>().Play();
		}else if(Global.GetInstance().MusicOff == true && gameObject.GetComponent<AudioSource>().isPlaying == true){
			gameObject.GetComponent<AudioSource>().Stop();
		}
	}
}
