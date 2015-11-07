using UnityEngine;
using System.Collections;

public class DelayDestroy : MonoBehaviour
{
    public float DelaySecond;

    // Use this for initialization
    void Start()
    {
        Invoke("Destroyself", DelaySecond);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Destroyself()
    {
        Destroyself();
    }
}