using System.Collections;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public float DelaySecond;

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