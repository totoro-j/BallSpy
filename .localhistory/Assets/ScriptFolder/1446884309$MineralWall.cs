using UnityEngine;
using System.Collections;

public class MineralWall : MonoBehaviour
{
    public GameObject Trigger;

    public tk2dSprite _sprite;

    
    public Transform[] TransformArray;
	// Use this for initialization
	void Start ()
	{
	    _sprite = GetComponent<tk2dSprite>();

	}
	
	// Update is called once per frame
	void Update () {
        	
	}
}
