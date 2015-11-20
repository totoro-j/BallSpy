using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour
{
    //星星数量
    public int StarNumber;

    //开启星级评价
    public bool StarEnable;

    public GameObject[] StarObjects;
    // Use this for initialization
    void Awake()
    {
        if (StarEnable != true)
        {
            Destroy(gameObject);
        }
        else
        {
            foreach (GameObject  star in StarObjects)
            {
                star.GetComponent<WinStar>().StarNumber = StarNumber;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}