using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//被警卫的粒子子弹击中后，机器人后退的粒子触发情况
	void OnParticleCollision(GameObject other){
		Vector3 getTrans = new Vector3(gameObject.transform.position [0] - other.transform.position [0], gameObject.transform.position [1] - other.transform.position [1], 0);
		transform.Translate (getTrans/50);
	}
}
