using System.Collections;
using UnityEngine;

public class ParticelDelayDestroy : MonoBehaviour
{
    /// <summary>
    ///延迟停止时间
    /// </summary>
    public float DelaySecondStop;

    public float DelaySecondDestroy;

    // Use this for initialization
    private void Start()
    {
        Invoke("Destroyself", DelaySecond);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void Destroyself()
    {
        Destroy(gameObject);
    }
}