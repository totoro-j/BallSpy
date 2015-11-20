using UnityEngine;
using System.Collections;

public class ScreenProgress : MonoBehaviour
{
    //当前值与最高值
    public int Value;
    public int Max;

    //比例增长
    private float _rate;

	// Use this for initialization
	void Start () {
	    if (Value == Max)
	    {
	        _rate = 1f;
	        GetComponent<UISprite>().fillAmount = _rate;
	    }
	    else
	    {
	        _rate = (float) Value/(float) Max;
	    }

	}
	
	// Update is called once per frame
	void Update () {

	    if (GetComponent<UISprite>().fillAmount < _rate)
	    {

	        if (GetComponent<UISprite>().fillAmount < _rate - 0.05f)
	        {
	            GetComponent<UISprite>().fillAmount += 0.02f;
	        }
	        else
	        {
	            GetComponent<UISprite>().fillAmount = _rate;
	        }
	    }

	}
}
