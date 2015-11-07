using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    public int Sum;
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

        /// <summary>
        /// 初始化计时
        /// </summary>
        /// <param name="sum"></param>
        Timer(int sum)
        {
            _sum = sum;
        }

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
    }
}