using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveSelect : MonoBehaviour {
	public GameObject save_star_01;
	public GameObject save_star_02;
	public GameObject save_star_03;
	public GameObject save_file_01;
	public GameObject save_file_02;
	public GameObject save_file_03;
	public GameObject save_star_num_01;
	public GameObject save_star_num_02;
	public GameObject save_star_num_03;
	public GameObject save_new_01;
	public GameObject save_new_02;
	public GameObject save_new_03;
	public GameObject save_bg_01;
	public GameObject save_bg_02;
	public GameObject save_bg_03;
	public int CurrentLevelScene;
	public int TotalLevelStars;
	// Use this for initialization
	void Start () {
		if (!ES2.Exists ("player01.dat")) {
			save_star_01.gameObject.SetActive (false);
			save_file_01.gameObject.SetActive (false);
			save_star_num_01.gameObject.SetActive (false);
			save_bg_01.GetComponent<UISprite>().spriteName = "save_0";
		} else {
			CurrentLevelScene = ES2.Load<int>("player01.dat?tag=CurrentLevelScene");
			switch(CurrentLevelScene){
			case 1:
				save_new_01.SetActive(false);
				save_bg_01.GetComponent<UISprite>().spriteName = "save_1";
				save_star_num_01.GetComponent<UILabel>().text = "0/30";
				break;
			case 2:
				save_new_01.SetActive(false);
				save_bg_01.GetComponent<UISprite>().spriteName = "save_2";
				save_star_num_01.GetComponent<UILabel>().text = "0/30";
				break;
			case 3:
				save_new_01.SetActive(false);
				save_bg_01.GetComponent<UISprite>().spriteName = "save_3";
				save_star_num_01.GetComponent<UILabel>().text = "0/30";
				break;
			default:
				break;
			}
		}
		if (!ES2.Exists ("player02.dat")) {
			save_star_02.gameObject.SetActive (false);
			save_file_02.gameObject.SetActive (false);
			save_star_num_02.gameObject.SetActive (false);
			save_bg_02.GetComponent<UISprite>().spriteName = "save_0";
		} else {
			CurrentLevelScene = ES2.Load<int>("player02.dat?tag=CurrentLevelScene");
			switch(CurrentLevelScene){
			case 1:
				save_new_02.SetActive(false);
				save_bg_02.GetComponent<UISprite>().spriteName = "save_1";
				save_star_num_02.GetComponent<UILabel>().text = "0/30";
				break;
			case 2:
				save_new_02.SetActive(false);
				save_bg_02.GetComponent<UISprite>().spriteName = "save_2";
				save_star_num_02.GetComponent<UILabel>().text = "0/30";
				break;
			case 3:
				save_new_02.SetActive(false);
				save_bg_02.GetComponent<UISprite>().spriteName = "save_3";
				save_star_num_02.GetComponent<UILabel>().text = "0/30";
				break;
			default:
				break;
			}
		}
		if (!ES2.Exists ("player03.dat")) {
			save_star_03.gameObject.SetActive (false);
			save_file_03.gameObject.SetActive (false);
			save_star_num_03.gameObject.SetActive (false);
			save_bg_03.GetComponent<UISprite>().spriteName = "save_0";
		} else {
			CurrentLevelScene = ES2.Load<int>("player03.dat?tag=CurrentLevelScene");
			switch(CurrentLevelScene){
			case 1:
				save_new_03.SetActive(false);
				save_bg_03.GetComponent<UISprite>().spriteName = "save_1";
				save_star_num_03.GetComponent<UILabel>().text = "0/30";
				break;
			case 2:
				save_new_03.SetActive(false);
				save_bg_03.GetComponent<UISprite>().spriteName = "save_2";
				save_star_num_03.GetComponent<UILabel>().text = "0/30";
				break;
			case 3:
				save_new_03.SetActive(false);
				save_bg_03.GetComponent<UISprite>().spriteName = "save_3";
				save_star_num_03.GetComponent<UILabel>().text = "0/30";
				break;
			default:
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
