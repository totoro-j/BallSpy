using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class CleanMist : MonoBehaviour
{
    public GameObject Mist;
    string[] MistArray;
    string[] MistChild;
    string MistName;
    string MistType;
    int start = 1, length = 6;
    List<GameObject> MistAll = new List<GameObject>();
    //Use this for initialization
    void Start()
    {
        foreach (Transform child in Mist.transform)
        {
			//添加所有迷雾
            MistAll.Add(child.gameObject);
        }
        MistArray = new string[4];
        MistChild = new string[4];
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject == GameController.GetInstance().CurrentPlayerTrigger && other.CompareTag("Mist"))
        {
            List<GameObject> MistList = new List<GameObject>();
            List<GameObject> MistOtherList = new List<GameObject>();
            int MistCount;
            int RecoverCount;
            MistName = other.gameObject.name.Substring(start - 1, length);//获取迷雾物体的前缀
            MistArray = other.gameObject.name.Split('_');//分割迷雾名称
            MistType = MistArray[1];//获取迷雾物体的名字中的类型
            foreach (Transform child in Mist.transform)
            {
                MistChild = child.gameObject.name.Split('_');
                if (child.gameObject.name.Substring(start - 1, length) == MistName || (MistType == "Elevator" && MistChild[2] == MistArray[2]))
                {
					//如果子物体名称一致
                    MistList.Add(child.gameObject);
                }
                else
                {
                    MistOtherList.Add(child.gameObject);
                }
            }
            for (MistCount = 0; MistCount < MistList.Count; MistCount++)
            {
                if (MistList[MistCount].GetComponent<tk2dSprite>().color != new Color(1, 1, 1, 0))
                {
                    TweenParms CleanMist = new TweenParms();
                    //颜色Aplaha通道渐变至0
                    CleanMist.Prop("color", new Color(1, 1, 1, 0));
                    //回调函数
                    HOTween.To(MistList[MistCount].GetComponent<tk2dSprite>(), 0.5f, CleanMist);
                }
            }
            for (RecoverCount = 0; RecoverCount < MistOtherList.Count; RecoverCount++)
            {
                if (MistOtherList[RecoverCount].GetComponent<tk2dSprite>().color != new Color(1, 1, 1, 1))
                {
                    TweenParms RecoverMist = new TweenParms();
                    //颜色Aplaha通道渐变至0
                    RecoverMist.Prop("color", new Color(1, 1, 1, 1));
                    //回调函数
                    HOTween.To(MistOtherList[RecoverCount].GetComponent<tk2dSprite>(), 0.5f, RecoverMist);
                }
            }
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("Player") && gameObject == GameController.GetInstance().CurrentPlayerTrigger && other.CompareTag("MistCut")){
            int Count;
            for (Count = 0; Count < MistAll.Count; Count++)
            {
                MistArray = MistAll[Count].name.Split('_');
                MistType = MistArray[1];
                if (MistAll[Count].GetComponent<tk2dSprite>().color == new Color(1, 1, 1, 0) && MistType != "Elevator")
                {
                    TweenParms CutMist = new TweenParms();
                    //颜色Aplaha通道渐变至0
                    CutMist.Prop("color", new Color(1, 1, 1, 1));
                    //回调函数
                    HOTween.To(MistAll[Count].GetComponent<tk2dSprite>(), 0.5f, CutMist);
                }
            }
        }
    }

}
