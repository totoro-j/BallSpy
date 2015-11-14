using UnityEngine;
using System.Collections;

public class ButtonLoadShow : MonoBehaviour
{

    public GameObject LoadUIPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnClick()
    {
        //单击时生成载入提示
        GameObject temp =  Instantiate(LoadUIPrefab, Vector3.zero, Quaternion.identity) as GameObject;
    }
}
