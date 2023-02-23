using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float speed_x = 1f;
    public float speed_y = 0f;
    public int health = 1;
    public int pointVal = 1;

    public int contactDamage = 10;
    public string variant = "N/A";
    
    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    private bool collision_check_for_movement = false;

    protected void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed_x, 0));
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
        if (collision_check_for_movement) {
            // change direction if collided with an upper or lower wall.
            speed_y = speed_y * -1f;
            collision_check_for_movement = false;
        }
        _rigidbody2D.velocity = new Vector2(speed_x, speed_y);
    }

    void Update()
    {
        check_and_handle_death();
        handle_movement();
    }

    // private void OnTriggerEnter2D(Collider2D col) {
    //     Debug.Log("WAA");
    //     if (col.CompareTag("Bullet")) {
    //         health -= 10;
    //         Destroy(col.gameObject);
    //     } else {
    //         collision_check_for_movement = true;
    //     }

    //     if (col.CompareTag("End")) {
    //         Destroy(gameObject);
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Bullet")) {
            health -= 10;
            Destroy(col.gameObject);
        } else if (col.gameObject.CompareTag("Player")) {
            Debug.Log("Contact damage");
            _gameManager.handleContactAttack(contactDamage);
        }
        
        else {
            collision_check_for_movement = true;
        }

        // if (col.gameObject.CompareTag("End")) {
        //     Destroy(gameObject);
        // }
    }
}