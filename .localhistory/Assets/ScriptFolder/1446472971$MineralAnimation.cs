﻿using UnityEngine;
using System.Collections;

public class MineralAnimation : MonoBehaviour
{
    public void Play()
    {
        if (GetComponent<MineralParticleAnimation>() != null)
        {
            GetComponent<MineralParticleAnimation>().Active = true;
        }
    }

    public void Stop()
    {
        if (GetComponent<MineralParticleAnimation>() != null)
        {
            GetComponent<MineralParticleAnimation>().Active = false;
        }
    }
}