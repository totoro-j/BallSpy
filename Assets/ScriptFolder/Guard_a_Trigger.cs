using UnityEngine;
using System.Collections;

public class Guard_a_Trigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider AnimTrigger){
		if (AnimTrigger.gameObject.tag== "WB_TriggerDes") {
			//销毁第二关中生成的警卫
			Destroy (gameObject.transform.parent.transform.parent.gameObject);
		}
	}
}
