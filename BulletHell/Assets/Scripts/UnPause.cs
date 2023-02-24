using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnPause : MonoBehaviour
{
    private GameManager _gameManager;
    private GameManager _script;

    public void DoAnUnpause(){
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _script = _gameManager.GetComponent<GameManager>();
        Debug.Log("DOING AN UNPAUSE!");
        _script.Resume();
    }
}
