﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class GuardRouteSet : MonoBehaviour {

	// Use this for initialization

    public Sequence Guard_a_Movement;
    public GameObject ChildPosition;
    public float time;//平移时间
    private Transform _child;//位置空物体
    private int _childNum;//空物体编号
    private List<Transform> _Children;//空物体列表
    private Vector3 _Rotation;//旋转角度
	
    void Start () {
        //生成位置list
        _Children = new List<Transform>();   
        foreach (Transform child in ChildPosition.transform) {
            _Children.Add(child);
        }
        _childNum = 0;
        _Rotation = new Vector3(0, 0, 0);
        _GuardRotate();


	}
	
	// Update is called once per frame
	void Update () {
    }
private void _GuardTraslation(){
    while (_childNum == _Children.Count) {
        _childNum = -1;
    }
    _childNum++;
    _child=_Children[_childNum];
    HOTween.To(transform.parent.transform.parent.gameObject.transform, time, new TweenParms().Prop("position", _child.transform.position).OnComplete(_GuardRotate));
}

private void _GuardRotate(){
    if (_Rotation.z == 0) {
        _Rotation.z = 57;
    }
    else if (_Rotation.z == 57) {
        _Rotation.z = 114;
    }
    else if (_Rotation.z == 114) {
        _Rotation.z = 237;
    }
    else if (_Rotation.z == 237) {
        _Rotation.z = 0;
    }
    HOTween.To(transform.parent.gameObject.transform, 1, new TweenParms().Prop("rotation", _Rotation).OnComplete(_GuardTraslation));
}


}