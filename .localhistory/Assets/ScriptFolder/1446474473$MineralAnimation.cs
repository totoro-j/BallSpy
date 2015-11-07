using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    //挖矿可以累计挖的Fixed帧数
    public int Sum;

    //计时器初始化
    private Timer _timer;

    void Awake()
    {
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
    }

    private class Timer
    {
        private int _sum;

        bool Update()
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
        int Set(int sum)
        {
            _sum = sum;
        }
    }
}