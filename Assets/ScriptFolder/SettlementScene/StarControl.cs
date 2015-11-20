using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StarControl : MonoBehaviour
{
    //星星数量
    public int StarNumber;

    //星星总数
    public int StarSum;

    //动画间隔
    public float AnimInterval;

    //开启星级评价
    public bool StarEnable;

    //物体下挂载的一个星星样本
    private GameObject _starSample;
//
//    [HideInInspector]
//    public List<GameObject> StarObjectsList;
    // Use this for initialization
    void Awake()
    {
        if (StarEnable != true)
        {
            Destroy(gameObject);
        }
        else
        {
            //加入当前第一个挂载的星星
            _starSample = GetAChild(gameObject);

            GetAChild(_starSample).GetComponent<WinStar>().StarNumber = StarNumber;
//            print(_starSample);
//            StarObjectsList.Add(GetAChild(_starSample));


            if (StarSum > 1)
            {
                for (int i = 1; i < StarSum; i++)
                {
                    //生成整体对象
                   GameObject starback =  Instantiate(_starSample, transform.position, Quaternion.identity) as GameObject;
                  
                    //挂在本网格物体下
                    starback.transform.parent = gameObject.transform;
                    starback.transform.localScale = Vector3.one;
                    //获取子对象
                    GameObject star = GetAChild(starback);



                    //初始化星星内容
                    star.GetComponent<WinStar>().StarId = i+1;
                    star.GetComponent<WinStar>().Delay = GetAChild(_starSample).GetComponent<WinStar>().Delay + i * AnimInterval;
                    star.GetComponent<WinStar>().StarNumber = StarNumber;
               



//                    StarObjectsList.Add(star);


                }
               
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void IinitializeStar()
    {
        
    }

    //返回物体子对象
        GameObject GetAChild(GameObject obj)
        {
            return (from Transform child in obj.transform select child.gameObject).FirstOrDefault();
        }
}