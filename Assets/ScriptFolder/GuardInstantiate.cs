using UnityEngine;
using System.Collections;

public class GuardInstantiate : MonoBehaviour {
	public GameObject GuardPrefab;
	private int CountNum = 2;
	// Update is called once per frame
	
	void FixedUpdate () {
			//第二关中的警卫生成装置
			CountNum --;
			if(CountNum == 1){
				GameObject NewGuards;
				NewGuards = Instantiate(GuardPrefab, transform.position, transform.rotation) as GameObject;
				CountNum = 600;
			}
	}
}