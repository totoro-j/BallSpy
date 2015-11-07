using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    //挖矿可以累计挖的Fixed帧数
    public int Sum;

    //计时器初始化
    private Timer _timer = new Timer();

    private bool _active;
    void Awake()
    {
        //设置计时器
        _timer.Set(Sum);
    }

    /// <summary>
    /// 控制动画播放的函数
    /// </summary>
    public void Play()
    {
        //控制粒子动画
        if (GetComponent<MineralParticleAnimation>() != null)
        {
            GetComponent<MineralParticleAnimation>().Active = true;
        }

        _active = true;
    }

    /// <summary>
    /// 控制动画停止的函数
    /// </summary>
    ///
    public void Stop()
    {
        //控制粒子动画
        if (GetComponent<MineralParticleAnimation>() != null)
        {
            GetComponent<MineralParticleAnimation>().Active = false;
        }
    }

    private void FixedUpdate()
    {
        if (_active)
        {
            //当计时结束
            if (_timer.Update() == false)
            {
                Stop();
            }
        }
    }

    private class Timer
    {
        private int _sum;

        public bool Update()
        {
            //如果计时结束
            if (_sum <= 0)
            {
                return true;
            }

            //倒计时减少
            _sum--;
        }

        /// <summary>
        /// 设置 x
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public int Set(int sum)
        {
            _sum = sum;
        }
    }
}