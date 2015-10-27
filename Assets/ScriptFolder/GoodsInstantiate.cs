using UnityEngine;
using System.Collections;

public class GoodsInstantiate : MonoBehaviour {
	public GameObject GoodsPrefab;
	public bool InstantiateGoods = false;
	private int CountNum = 60;

	// Update is called once per frame
	void FixedUpdate () {
		//c型号工作台的货物生成器
		if(InstantiateGoods == true){
			CountNum --;
			if(CountNum == 1){
				GameObject NewGoods;
				NewGoods = Instantiate(GoodsPrefab, transform.position, transform.rotation) as GameObject;
				NewGoods.GetComponent<Rigidbody>().velocity = new Vector3(0.4f,0,0);
				CountNum = 120;
			}
		}
	}
}