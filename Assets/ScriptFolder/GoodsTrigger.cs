using UnityEngine;
using System.Collections;

public class GoodsTrigger : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider AnimTrigger){
		if (AnimTrigger.gameObject.tag == "WB_Trigger") {
			//c型工作台货物运动的自然下落
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
		} else if (AnimTrigger.gameObject.tag == "WB_TriggerDes") {
			//销毁掉落的货物
			Destroy (gameObject);
		}
	}


}
