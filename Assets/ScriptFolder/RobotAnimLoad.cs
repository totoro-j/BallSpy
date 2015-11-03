using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class RobotAnimLoad : MonoBehaviour {
	public GameObject g_01;
	public Sequence G_01;
	public GameObject Aim01;
	public GameObject Goods01;
	public GameObject Light01;
	public GameObject Lamp01;
	private int WorkNow = 0;//0是行走，1是边走边向右工作，2是只工作，3是边走边向左工作

	//load界面的动画加载
	// Use this for initialization
	void Start () {
		if (Global.GetInstance ().loadName == "Screen0101" && Application.loadedLevelName == "DemoLoading") {
			Aim01.SetActive (true);
			Goods01.GetComponent<GoodsInstantiate>().InstantiateGoods = true;
			G_01 = new Sequence (new SequenceParms ().Loops (-1, LoopType.Restart));
			G_01.Prepend (HOTween.To (g_01.gameObject.transform.parent.gameObject.transform, 2, new TweenParms ().Prop ("rotation", new Vector3 (0, 0, 108)).Ease (EaseType.EaseOutQuart)));
			G_01.Insert (2,HOTween.To (g_01.gameObject.transform.parent.gameObject.transform, 2, new TweenParms ().Prop ("rotation", new Vector3 (0, 0, 0)).Ease (EaseType.EaseOutQuart)));
			G_01.Insert (2,HOTween.To (gameObject.transform, 0, new TweenParms ().Prop ("localScale", gameObject.transform.localScale).Ease (EaseType.EaseOutQuart)));
			G_01.Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Global.GetInstance ().loadName == "Screen0101" && Application.loadedLevelName == "DemoLoading") {
			if (WorkNow == 0) {
				gameObject.transform.parent.gameObject.transform.Translate (1.8f * Time.deltaTime, 0f, 0f);
				gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_2_walk");
			} else if (WorkNow == 1) {
				gameObject.transform.parent.gameObject.transform.Translate (1.8f * Time.deltaTime, 0f, 0f);
				gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_2_work");
			} else if (WorkNow == 2) {
				gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Stop ();
			} else if (WorkNow == 3) {
				gameObject.transform.parent.gameObject.transform.Translate (-1.8f * Time.deltaTime, 0f, 0f);
				gameObject.transform.parent.gameObject.GetComponent<tk2dSpriteAnimator> ().Play ("Robot_2_work");
			}
		}
	}

	void OnTriggerEnter(Collider DoWork){
		if (DoWork.name == "WorkLeft") {
			WorkNow = 1;
			Aim01.SetActive (false);
			Light01.GetComponent<tk2dSprite>().SetSprite("绿光");
			Lamp01.GetComponent<tk2dSprite>().SetSprite("绿灯");
		} else if(DoWork.name == "Stop") {
			WorkNow = 2;
		} else if(DoWork.name == "WorkRight"){
			WorkNow = 3;
		}
	}
}
