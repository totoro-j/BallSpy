﻿using System.Collections;
using UnityEngine;

public class MineralParticleAnima : MonoBehaviour
{
    public GameObject ParticleObj;

    //以下为粒子动画播放时间开始后先延迟至Delay帧，播放Duration帧后停止，再Remaining帧停止时间，重新循环

    public int Delay;
    public int Duration;
    public int Remaining;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    }
}