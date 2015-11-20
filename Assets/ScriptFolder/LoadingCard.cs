using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingCard : MonoBehaviour
{
    //场景的名称列表
    public List<string> SceneName;

    //各个场景所对应的卡片名称
    public List<Vector2> CardRange;

    //所有卡片预设
    public List<GameObject> CardPrefabList;



	// Use this for initialization
    private void Awake()
    {
        //扫描
        for (int i = 0; i < SceneName.Count; i ++)
        {
            //如果存在当前名称的场景名
            if (SceneName[i] == Global.GetInstance().loadName)
            {
                int id;
                //如果范围相同，既只有一个
                if ((int) CardRange[i].x == (int) CardRange[i].y)
                {
                    id = (int) CardRange[i].x;
                }
                else
                {
                    id = (int) Random.Range(CardRange[i].x, CardRange[i].y + 0.99f);
                }

                //按照ID生成卡片
                GameObject card =
                    Instantiate(CardPrefabList[id - 1], transform.position, Quaternion.identity) as GameObject;
                card.transform.parent = transform;
                card.transform.localScale = Vector3.one;

                return;

            }

        }
        return;

    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
