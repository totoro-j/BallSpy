using System.Collections;
using UnityEngine;

public class ButtonForLoadLevel : MonoBehaviour
{
    public string ThisScreen;

    // Use this for initialization
    private void Start()
    {
    }

    /// <summary>
    /// 作为载入关卡的方法，被Button调用
    /// </summary>
    public void LoadLevel()
    {
		Global.GetInstance ().CurrentStayLevel = int.Parse (gameObject.name);
        Global.GetInstance().loadName = ThisScreen;
        Application.LoadLevel("DemoLoading");
    }
}