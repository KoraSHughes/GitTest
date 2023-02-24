using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefab;

    public string nextLevel;

    int _enemyType;

    IEnumerator Start()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            for (int i = 0; i < 20; ++i) {
                Vector2 spawnPos = new Vector2(Random.Range(11,15), Random.Range(-4f,4f));
                Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            for (int i = 0; i < 15; ++i)
            {
                Vector2 spawnPos = new Vector2(Random.Range(11, 15), Random.Range(-4f, 4f));
                _enemyType = Random.Range(0, 100);
                if(_enemyType >= 33)
                {
                    Instantiate(enemyPrefab[0], spawnPos, Quaternion.identity);
                }
                else if(_enemyType < 33)
                {
                    Instantiate(enemyPrefab[1], spawnPos, Quaternion.identity);
                }
                yield return new WaitForSeconds(1.5f);
            }
        }

        while(true)
        {
            yield return new WaitForSeconds(20f);
            SceneManager.LoadScene(nextLevel);
        }
    }
}
