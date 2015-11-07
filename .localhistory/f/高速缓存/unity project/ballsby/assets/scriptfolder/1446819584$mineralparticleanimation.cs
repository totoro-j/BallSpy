using System.Collections;
using UnityEngine;

public class MineralParticleAnimation : MonoBehaviour
{
    public GameObject ParticleObj;

    public GameObject ParticleBoomPrefab;
    //以下为粒子动画播放时间开始后先延迟至Delay帧，播放Duration帧后停止，再Remaining帧停止时间，重新循环

    public int Delay;
    public int Duration;
    public int Remaining;

    //表示激活状态
    public bool Active;

    //计时帧
    private int _frame;

    // Use this for initialization
    private void Start()
    {
        //初始化
        _frame = 0;
        ParticleObj.GetComponent<ParticleSystem>().enableEmission = true;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //未激活就返回
        if (Active == false)
        {
            if (ParticleObj.GetComponent<ParticleSystem>().enableEmission == true)
            {
                _frame = 0;
                ParticleObj.GetComponent<ParticleSystem>().enableEmission = false;
            }
            return;
        }
        if (_frame == Delay + Duration + Remaining)
        {
            _frame = 0;
            return;
        }
        else if (_frame == Delay + Duration)
        {
            ParticleObj.GetComponent<ParticleSystem>().enableEmission = false;
        }
        else if (_frame == Delay)
        {
            ParticleObj.GetComponent<ParticleSystem>().enableEmission = true;
        }
        _frame++;
    }
}