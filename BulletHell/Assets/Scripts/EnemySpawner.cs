using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    IEnumerator Start()
    {
        for (int i = 0; i < 50; ++i) {
            Vector2 spawnPos = new Vector2(Random.Range(8,15), Random.Range(-3f,3.5f));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
