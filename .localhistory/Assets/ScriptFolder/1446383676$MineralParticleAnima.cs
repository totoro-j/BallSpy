using System.Collections;
using UnityEngine;

public class MineralParticleAnima : MonoBehaviour
{
    public GameObject ParticleObj;

    //以下为粒子动画播放时间开始后先延迟至Delay帧，播放Duration帧后停止，再Remaining帧停止时间，重新循环

    public int Delay;
    public int Duration;
    public int Remaining;

    //表示激活状态
    private bool _active;

    //计时帧
    private int _frame;

    // Use this for initialization
    private void Start()
    {
        //初始化
        _frame = 0;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_frame == Delay + Duration + Remaining)
        {
            _frame = 0;
            return;
        }
        else if (_frame == Delay + Duration)
        {
            ParticleObj.GetComponent<ParticleEmitter>().emit = false;
        }
        _frame++;
    }
}