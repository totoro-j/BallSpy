using UnityEngine;
using System.Collections;

public class ParticlePlayer : MonoBehaviour {
	public GameObject BallPlayerDes;
	GameObject Pi;

	//小球被警卫子弹击中后，生成碎块替身
	void OnParticleCollision(GameObject other){
		if(GameController.GetInstance().ShootOnce == true){
			GameController.GetInstance().ShootOnce = false;
			Pi = Instantiate(BallPlayerDes, transform.position, Quaternion.identity) as GameObject;                     
			gameObject.GetComponent<tk2dSprite> ().color = new Color (1,1,1,0);
			gameObject.GetComponent<Rigidbody>().Sleep();
			GameObject.Find("Camera01").transform.position = new Vector3(Pi.transform.position[0],Pi.transform.position[1],-23.1f);
			StartCoroutine(WaitDie(2.0f));
		}
	}

	IEnumerator WaitDie(float value) //等待的时间,单位秒  
	{   
		yield return new WaitForSeconds (value); 
		Destroy (Pi);
		gameObject.SetActive (false);
		GameController.GetInstance().ShootOnce = true;
	}
}
