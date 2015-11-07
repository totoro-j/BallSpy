using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    /// <summary>
    /// 控制动画播放的函数
    /// </summary>
    public void Play()
    {
        if (GetComponent<MineralParticleAnimation>() != null)
        {
            GetComponent<MineralParticleAnimation>().Active = true;
        }
    }
    /// <summary>
    /// 控制动画播放的函数
    /// </summary>
    public void Stop()
    {
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

        Timer(int sum)
        {
            _sum = sum;
        }
    }
}