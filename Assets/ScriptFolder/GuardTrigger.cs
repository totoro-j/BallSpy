using UnityEngine;
using System.Collections;

public class GuardTrigger : MonoBehaviour {
    public char Guard;
	private GameObject GuardDestroy;

	// Use this for initialization
	void Start () {
		GuardDestroy = gameObject.transform.parent.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider AnimTrigger){
        if(Guard=='a'){
		    if (AnimTrigger.gameObject.tag== "GA_TriggerDes") {
			    //销毁第二关中生成的警卫
			    Destroy (GuardDestroy);
            }
		}else if(Guard=='b'){
            if (AnimTrigger.gameObject.tag == "GB_TriggerDes")
            {
                //销毁第二关中生成的警卫
                Destroy(GuardDestroy);
            }
        
        }else if(Guard=='c'){
                if (AnimTrigger.gameObject.tag== "GC_TriggerDes") {
			    //销毁第二关中生成的警卫
			    Destroy (GuardDestroy);
                }
        
        }
       }
}
