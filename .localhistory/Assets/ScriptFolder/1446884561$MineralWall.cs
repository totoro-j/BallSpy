using UnityEngine;
using System.Collections;

public class MineralWall : MonoBehaviour
{
    /// <summary>
    /// 触发器对象
    /// </summary>
    public GameObject Trigger;

    //物体本身的精灵脚本
    public tk2dSprite _sprite;

    //触发器在不同阶段的位置
    public Transform[] TransformArray;
    // Use this for initialization
    void Start()
    {
        //获得物体上的精灵脚本
        _sprite = GetComponent<tk2dSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        Trigger.transform = TransformArray[_sprite.spriteId];
    }
}