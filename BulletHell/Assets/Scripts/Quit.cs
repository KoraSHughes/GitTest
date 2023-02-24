using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void DoAQuit(){
#if !UNITY_WEBGL
        Application.Quit();
    }
#endif

    public void DoARestart()
    {
        SceneManager.LoadScene("Level1");
    }
}
