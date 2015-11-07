using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    //挖矿可以累计挖的Fixed帧数
    public int SumFrame;

    //计时器初始化
    private Timer _timer = new Timer();

    public bool Active;
    void Awake()
    {
        //设置计时器
        _timer.Set(SumFrame);
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

        Active = true;
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
        Active = false;
    }

    private void FixedUpdate()
    {
        if (Active)
        {
            //当计时结束
            if (_timer.Update() == false)
            {
                Stop();
            }
        }
    }

    //以下为动画内部类

    //动画计时器类
    private class Timer
    {
        private int _sum;
        private int _sum;
        //刷新
        public bool Update()
        {
            //如果计时结束
            if (_sum <= 0)
            {
                return false;
            }

            //倒计时减少
            _sum--;
            return true;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public void Set(int sum)
        {
            _sum = sum;
        }
    }

    //    /// <summary>
    //    /// 震动动画类
    //    /// </summary>
    //    private class ShakeAnimation
    //    {
    //
    //    }
}