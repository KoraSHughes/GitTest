using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeScene(string sceneToLoad)
    {
        Debug.Log("Yay, you did it! Moving to " + sceneToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit(){
//#if !UNITY_WEBGL
        Application.Quit();
    }
//#endif
}