using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int speed = 30;
    int health = 50;
    int pointVal = 10;
    
    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        if (health <= 0) {
            _gameManager.AddScore(pointVal);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Bullet")) {
            health -= 10;
            Destroy(col.gameObject);
        }

        if (col.CompareTag("End")) {
            Destroy(gameObject);
        }
    }
}
