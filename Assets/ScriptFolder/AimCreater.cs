using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class AimCreater : MonoBehaviour {
	public List<GameObject> WorkSpaceComponent = new List<GameObject>();
	public bool isAimPlay = true;//通常状态下，Aim不播放动画，处于静止状态

	void Awake () {
		//初始时，令每个工作台的Aim处于失效状态
		foreach (Transform child in transform) {
			WorkSpaceComponent.Add (child.gameObject);//将场景中所有工作间添加进list中
		}
		WorkSpaceComponent [0].SetActive (false);
	}

	void Update () {
		//如果Aim处于静止状态
		if(isAimPlay == true){
			//调用Aim的动画播放
			AimAnim();
			//令该判断只调用一次
			isAimPlay = false;
		}
	}

	void AimAnim(){
		Vector3 v1 = new Vector3 (0,0,179);
		Vector3 v2 = new Vector3 (0,0,-179);
		Sequence AimAnim = new Sequence(new SequenceParms().Loops(-1,LoopType.Restart));
		AimAnim.Prepend(HOTween.To(WorkSpaceComponent [0].transform, 1, new TweenParms().Prop("rotation", v1)));
		AimAnim.Append(HOTween.To(WorkSpaceComponent [0].transform, 1, new TweenParms().Prop("rotation", v2)));
		AimAnim.Play ();//旋转瞄准镜动画
	}
}
