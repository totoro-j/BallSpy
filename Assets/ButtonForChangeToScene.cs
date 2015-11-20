using UnityEngine;
using System.Collections;

public class ButtonForChangeToScene : MonoBehaviour
{
    public string SceneName;
    // Use this for initialization

    //通过外部调用本函数来进行场景变更
    public void ChangeScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(SceneName);//回到主菜单
    }
}