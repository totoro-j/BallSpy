using System.Collections;
using UnityEngine;

public class ParticelDelayDestroy : MonoBehaviour
{
    /// <summary>
    ///延迟停止时间
    /// </summary>
    public float DelaySecondStop;

    /// <summary>
    ///延迟毁灭
    /// </summary>
    public float DelaySecondDestroy;

    // Use this for initialization
    private void Start()
    {
        Invoke("Stop", Stop);
        Invoke("Destroyself", DelaySecondDestroy);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void Stop()
    {
        GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void Destroyself()
    {
        Destroy(gameObject);
    }
}