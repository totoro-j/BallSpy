using System.Collections;
using UnityEngine;

public class WinStar : MonoBehaviour
{
    //星级评价的数量
    [HideInInspector]
    public int StarNumber;

    //星星的ID，如果ID高于星级数量则不显示，即未获得
    public int StarId;

    //延迟时间
    public float Delay;

    // Use this for initialization
    private void Start()
    {
        //星星足够便播放出现动画
        if (StarNumber >= StarId)
        {
            Invoke("Play", Delay);
        }
    }

    //播放出现动画
    private void Play()
    {
        GetComponent<TweenRotation>().PlayForward();

        GetComponent<TweenScale>().PlayForward();
    }
}