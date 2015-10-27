using UnityEngine;
using System.Collections;

public class ButtonDeleteSave : MonoBehaviour {
	public string DeletedSaveName;
	public GameObject save_star;
	public GameObject save_file;
	public GameObject save_star_num;
	public GameObject save_bg;
	public GameObject save_new;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnClick () {
		if(ES2.Exists(DeletedSaveName)){
			ES2.Delete (DeletedSaveName);
		}
		save_star.gameObject.SetActive (false);
		save_file.gameObject.SetActive (false);
		save_star_num.gameObject.SetActive (false);
		save_bg.GetComponent<UISprite>().spriteName = "save_0";
		save_new.SetActive(true);
	}
}
