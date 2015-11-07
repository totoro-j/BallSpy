using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    //挖矿可以累计挖的Fixed帧数
    public int SumFrame;

    public bool Active;
    public GameObject ParticleBoomPrefab;

    public Transform[] ParticleBoomTransform;
    //图片ID
    private int id;

    //计时器初始化
    private Timer _timer = new Timer();

    void Awake()
    {
        //设置计时器
        _timer.Set(SumFrame);

        //设置图片ID
        id = 0;
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

                //播放毁灭动画
                GameObject temp = Instantiate(ParticleBoomPrefab, ParticleBoomTransform[3].position, Quaternion.identity) as GameObject;
                Destroy(gameObject);
            }

            //小破
            if (_timer.Rate() <= 0.75f && id <= 0)
            {
                GameObject temp = Instantiate(ParticleBoomPrefab, ParticleBoomTransform[id].position, Quaternion.identity) as GameObject;
                id++;
                GetComponent<tk2dSprite>().spriteId = id;
            }

            //中破
            if (_timer.Rate() <= 0.5f && id <= 1)
            {
                GameObject temp = Instantiate(ParticleBoomPrefab, ParticleBoomTransform[id].position, Quaternion.identity) as GameObject;
                id++;
                GetComponent<tk2dSprite>().spriteId = id;
            }

            //大破
            if (_timer.Rate() <= 0.25f && id <= 2)
            {
                GameObject temp = Instantiate(ParticleBoomPrefab, ParticleBoomTransform[id].position, Quaternion.identity) as GameObject;

                id++;

                GetComponent<tk2dSprite>().spriteId = id;
            }
        }
    }

    //以下为动画内部类

    //动画计时器类
    private class Timer
    {
        //累计计时
        private int _sum;

        //计时最大数值
        private int _maxSum;

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
        /// 获得矿物摧毁比例
        /// </summary>
        /// <returns></returns>
        public float Rate()
        {
            if (_sum == 0)
            {
                return 1f;
            }
            return ((float)_sum) / ((float)_maxSum);
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public void Set(int sum)
        {
            _sum = sum;
            _maxSum = sum;
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