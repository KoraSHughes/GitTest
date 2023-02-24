using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void DoAQuit(){
#if !UNITY_WEBGL
        Application.Quit();
    }
#endif
}
