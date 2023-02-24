using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    GameManager _gameManager;

    bool allowDamage = true;

    float secSinceLastDamage = 0.0f;

    public float allowDamageInterval = 1.0f;
    // Start is called before the first frame update
    private void Start() {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update() {
        if (!allowDamage) {
            secSinceLastDamage += Time.deltaTime;
            if (secSinceLastDamage >= allowDamageInterval) {
                allowDamage = true;
                secSinceLastDamage = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameManager.HealthDecr(damage);
            allowDamage = false;
        }
    }
}
