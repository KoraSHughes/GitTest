using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefab;

    public string nextLevel;

    int _enemyType;

    int _enemyColor;

    Vector2 spawnPos;
    IEnumerator Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            for (int i = 0; i < 20; ++i) {
                spawnPos = new Vector2(Random.Range(11,15), Random.Range(-4f,4f));
                _enemyColor = Random.Range(0, 3);
                Instantiate(enemyPrefab[_enemyColor], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            for (int i = 0; i < 25; ++i)
            {
                spawnPos = new Vector2(Random.Range(11, 15), Random.Range(-4f, 4f));
                _enemyType = Random.Range(0, 100);
                if(_enemyType >= 40)
                {
                    //Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
                    _enemyColor = Random.Range(0,3);
                    Instantiate(enemyPrefab[_enemyColor], spawnPos, Quaternion.identity);
                }
                else if(_enemyType < 40)
                {
                    //Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);
                    _enemyColor = Random.Range(3, 6);
                    Instantiate(enemyPrefab[_enemyColor], spawnPos, Quaternion.identity);
                }
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            for (int i = 0; i < 40; ++i)
            {
                spawnPos = new Vector2(Random.Range(11, 15), Random.Range(-4f, 4f));
                _enemyType = Random.Range(0, 100);
                if(_enemyType >= 70)
                {
                    //Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
                    _enemyColor = Random.Range(0,3);
                    Instantiate(enemyPrefab[_enemyColor], spawnPos, Quaternion.identity);
                }
                else if(_enemyType < 70)
                {
                    //Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);
                    _enemyColor = Random.Range(3, 6);
                    Instantiate(enemyPrefab[_enemyColor], spawnPos, Quaternion.identity);
                }
                yield return new WaitForSeconds(1f);
            }
            spawnPos = new Vector2(11, 0);
            Instantiate(enemyPrefab[6], spawnPos, Quaternion.identity);
        }

        while(true)
        {
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                yield return new WaitForSeconds(5f);
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
