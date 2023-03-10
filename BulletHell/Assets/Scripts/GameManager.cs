using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score = 0, health = 100;
    public static bool pause = false;

    public TextMeshProUGUI scoreUI, healthUI;
    public GameObject pauseUI;

    private void Awake() {
        // if (GameObject.FindObjectsOfType<GameManager>().Length > 1) {
        //     Destroy(gameObject);
        // }
        // else {
        //     DontDestroyOnLoad(gameObject);
        // }
    }

    private void Start()
    {
        scoreUI.text = "SCORE: " + score;
        healthUI.text = "HEALTH: " + health;
        pauseUI.SetActive(false);
    }

    public void AddScore(int points) {
        score += points;
        scoreUI.text = "SCORE: " + score;
    }

    public void HealthDecr(int points) {
        health -= points;
        healthUI.text = "HEALTH: " + health;
        if(health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pause) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public int GetHealth()
    {
        return health;
    }

/*     public void handleContactAttack(int dmg) {
        health -= dmg;
    }

    public void handleLaserAttack(int dmg) {
        health -= dmg;

    } */
}