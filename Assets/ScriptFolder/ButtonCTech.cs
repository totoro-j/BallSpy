using UnityEngine;
using System.Collections;

public class ButtonCTech : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LoadLevel () {
		Global.GetInstance().loadName = "DemoTech";  //该脚本之后合并到ButtonC0101脚本中
		Application.LoadLevel("DemoLoading");
	}
}
