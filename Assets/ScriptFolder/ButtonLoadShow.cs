using UnityEngine;
using System.Collections;

public class ButtonLoadShow : MonoBehaviour
{

    public GameObject LoadUIPrefab;

	GameObject _temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
		if (_temp != null) 
		{
			return;
		}
        //单击时生成载入提示
         _temp =  Instantiate(LoadUIPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		GameObject uiRoot = GameObject.Find("UI Root");
		_temp.transform.parent = uiRoot.transform;
		_temp.transform.localScale = Vector3.one;
	
    }
}
