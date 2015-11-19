using UnityEngine;
using System.Collections;

public class GuardTrigger : MonoBehaviour {
    public char Guard;
	private GameObject GuardDestroy;//警卫移动结束位置
	public GameObject GuardInstiate;//警卫移动初始位置
	private Transform _GuardBody;

	// Use this for initialization
	void Start () {
		_GuardBody=transform.parent.transform.parent.gameObject.transform;
		GuardDestroy = gameObject.transform.parent.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider AnimTrigger){
        if(Guard=='a'){
		    if (AnimTrigger.gameObject.CompareTag("GA_TriggerDes")) {
				//将小球的位置移到初始位置
				_GuardBody.position = new Vector3(GuardInstiate.transform.position.x, GuardInstiate.transform.position.y, GuardInstiate.transform.position.z);
            }
		}else if(Guard=='b'){
            if (AnimTrigger.gameObject.CompareTag("GB_TriggerDes"))
            {
				//将小球的位置移到初始位置
				_GuardBody.position = new Vector3(GuardInstiate.transform.position.x, GuardInstiate.transform.position.y, GuardInstiate.transform.position.z);            }
        
        }else if(Guard=='c'){
                if (AnimTrigger.gameObject.CompareTag("GC_TriggerDes"))
			{
				//将小球的位置移到初始位置
				_GuardBody.position = new Vector3(GuardInstiate.transform.position.x, GuardInstiate.transform.position.y, GuardInstiate.transform.position.z);            }
        
        }
       }
}
