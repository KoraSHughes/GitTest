using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject _gameManager;

    public void PlayGame() {
        SceneManager.LoadScene("Level1");
    }

    public void Resume() {
        _gameManager.GetComponent<GameManager>().Resume();
    }

    public void QuitGame() {
        Application.Quit();
    }
}
