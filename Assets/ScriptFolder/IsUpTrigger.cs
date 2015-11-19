using UnityEngine;
using System.Collections;

public class IsUpTrigger : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	//用于流水线机器人的从电梯出来时自动上升
	void OnTriggerStay(Collider other){
		if(other.CompareTag("ground")){
			//c型号机器人在从电梯上陆时自动提升到自身高度
			gameObject.transform.parent.transform.position = new Vector3(gameObject.transform.parent.transform.position[0],gameObject.transform.parent.transform.position[1]+0.1f,gameObject.transform.parent.transform.position[2]);
			gameObject.transform.parent.GetComponent<Rigidbody>().useGravity = false;
			gameObject.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
		}else if(other.CompareTag("cavity")){
			gameObject.transform.parent.GetComponent<Rigidbody>().useGravity = true;
		}
	}
}
