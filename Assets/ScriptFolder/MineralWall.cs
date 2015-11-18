using UnityEngine;
using System.Collections;

public class MineralWall : MonoBehaviour
{
    /// <summary>
    /// 触发器对象
    /// </summary>
    public GameObject Trigger;

    /// <summary>
    /// 粒子
    /// </summary>
    public GameObject Particle;
    
    //物体本身的精灵脚本
    private tk2dSprite _sprite;

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
        //改变各部件位置
        Trigger.transform.position = TransformArray[_sprite.spriteId].position;
        Particle.transform.position = TransformArray[_sprite.spriteId].position;
    }
}