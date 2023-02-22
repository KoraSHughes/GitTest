using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class Enemy : MonoBehaviour
{
    protected float speed_x = 1f;
    protected float speed_y = 1f;
    protected int health = 1;
    protected int pointVal = 1;
    protected float attackInterval = 1.0f;

    protected float secSinceLastAttack = 0.0f;

    public char movementDirection = 'H'; // either Vertical or Horizontal.
    
    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    private bool collision_check_for_movement = false;

    protected void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    protected void check_and_handle_death()
    {
        if (health <= 0) {
            _gameManager.AddScore(pointVal);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // handles enemy movement behavior.
    protected void handle_movement()
    {
        float change_dir = 1f;
        if (collision_check_for_movement) {
            change_dir = -1f;
            collision_check_for_movement = false;
        }
        _rigidbody2D.velocity = new Vector2(speed_x, speed_y * change_dir);
    }

    // void Update() {}

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Bullet")) {
            health -= 10;
            Destroy(col.gameObject);
        } else {
            collision_check_for_movement = true;
        }
        if (col.CompareTag("End")) {
            Destroy(gameObject);
        }
    }

    protected void attack()
    {
        Debug.Log("Enemy attacked...");
    }
}