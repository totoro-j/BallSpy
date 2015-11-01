using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class Guard_a_Moving : MonoBehaviour {
	public Sequence Guard_a_Movement;
	public float x;
	public float time;
	public int isPrefab;//0代表着正常警卫机器人，1代表的是,且为纵向移动，2代表是且为横向移动
	//摄像机初始时播放镜头推进放大动画
	void Start () {
		if (isPrefab == 0) {
			//一般情况下a型号警卫的运动方式
			Guard_a_Movement = new Sequence (new SequenceParms ().Loops (-1, LoopType.Restart));
			Guard_a_Movement.Prepend (HOTween.To (transform.parent.transform.parent.gameObject.transform, time, new TweenParms ().Prop ("position", new Vector3 (transform.parent.transform.parent.gameObject.transform.position [0] - x, transform.parent.transform.parent.gameObject.transform.position [1], transform.parent.transform.parent.gameObject.transform.position [2]))));
			Guard_a_Movement.Append (HOTween.To (transform.parent.gameObject.transform, 2, new TweenParms ().Prop ("rotation", new Vector3 (0, 0, 108)).Ease (EaseType.EaseOutQuart)));
			Guard_a_Movement.Append (HOTween.To (transform.parent.transform.parent.gameObject.transform, time, new TweenParms ().Prop ("position", new Vector3 (transform.parent.transform.parent.gameObject.transform.position [0], transform.parent.transform.parent.gameObject.transform.position [1], transform.parent.transform.parent.gameObject.transform.position [2]))));
			Guard_a_Movement.Append (HOTween.To (transform.parent.gameObject.transform, 2, new TweenParms ().Prop ("rotation", new Vector3 (0, 0, 0)).Ease (EaseType.EaseOutQuart)));
			Guard_a_Movement.Play ();
		}
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isPrefab == 1) {
            transform.parent.transform.parent.transform.position = new Vector3(transform.parent.transform.parent.transform.position.x - x, transform.parent.transform.parent.transform.position.y, transform.parent.transform.parent.transform.position.z);
		}
        if (isPrefab == 2) {
            transform.parent.transform.parent.transform.position = new Vector3(transform.parent.transform.parent.transform.position.x, transform.parent.transform.parent.transform.position.y-x, transform.parent.transform.parent.transform.position.z);
        }
	}
	

}
