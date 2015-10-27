using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class WorkSpaceController : MonoBehaviour {
	public bool isWorkSpacePlay = false;
	public GameObject MyNameIsWorkSpace;//启动的工作台
	public string CurrentWorkSpaceType;//当前玩家机器人所在工作台前缀（用于判断工作台型号）

	public void WorkSpaceControl(){
		//工作台动画播放控制器
		List<GameObject> TempComponent = new List<GameObject>();
		List<GameObject> TempOtherComponent = new List<GameObject>();
		if (isWorkSpacePlay == true) {
			switch (CurrentWorkSpaceType) {
			case "Robot_1-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [8].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [10].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [9].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [11].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [7].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();	
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();			
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [5].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();				
				break;

			case "Robot_2-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [1].GetComponent<GoodsInstantiate>().InstantiateGoods = true;
				TempComponent [2].GetComponent<tk2dSprite>().SetSprite("绿光");
				TempComponent [3].GetComponent<tk2dSprite>().SetSprite("绿灯");
				break;

			case "Robot_3-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();				
				break;

			case "Robot_3-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
					TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();

					TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();				
				break;
			

			
			case "Robot_4-1":
			case "Robot_4-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();			
				break;
						
			case "Robot_5-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				TempComponent [4].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();			
				break;
			
			case "Robot_5-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();	
				foreach (Transform child in TempComponent[3].transform) {
					TempOtherComponent.Add (child.gameObject);
				}
				TempOtherComponent [1].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Play();
				break;
				
			default:
				break;
			}
		}else if(isWorkSpacePlay == false) {
			switch (CurrentWorkSpaceType) {
			case "Robot_1-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [8].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [10].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [9].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [11].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [7].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();			
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [5].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();			
				break;

			case "Robot_2-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [1].GetComponent<GoodsInstantiate>().InstantiateGoods = false;
				TempComponent [2].GetComponent<tk2dSprite>().SetSprite("红光");
				TempComponent [3].GetComponent<tk2dSprite>().SetSprite("红灯");
				break;
				
			case "Robot_3-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();				
				break;
				
			case "Robot_3-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();			
				break;
				
			case "Robot_4-1":
			case "Robot_4-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();			
				break;
				
			case "Robot_5-1":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [2].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				TempComponent [4].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();			
				break;
				
			case "Robot_5-2":
				foreach (Transform child in MyNameIsWorkSpace.transform) {
					TempComponent.Add (child.gameObject);
				}
				TempComponent [3].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();				
				foreach (Transform child in TempComponent[3].transform) {
					TempOtherComponent.Add (child.gameObject);
				}
				TempOtherComponent [1].GetComponent<WorkSpaceAnimSelection>().ComponentAnim.Pause();
				break;
				
			default:
				break;
			}
		}
	}
}
