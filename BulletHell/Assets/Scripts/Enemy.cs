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

    // int bulletSpeed = 300;
    float time = 0f;

    public int contactDamage = 10;
    public float allowDamageInterval = 1f;

    public GameObject[] _laserTypes;
    public string variant = "N/A";
    
    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    SpriteRenderer _player_sprite;

    private bool collision_check_for_movement = false;
    private bool allowDamage = true;
    private float secSinceLastDamage = 0f;

    protected void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed_x, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        time = 1.0f;
    }

    protected void check_and_handle_death()
    {
        if (health <= 0) {
            _gameManager.AddScore(pointVal);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(explosion);
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

        if(time > 0f)
        {
            time -= Time.deltaTime;
        }

        if(time <= 0)
        {
            
        }
        if (!allowDamage) {
            secSinceLastDamage += Time.deltaTime;
            if (secSinceLastDamage >= allowDamageInterval) {
                allowDamage = true;
                secSinceLastDamage = 0f;
            }
        }
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

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Bullet")) {
            health -= 10;
            Destroy(col.gameObject);
        } else if (col.gameObject.CompareTag("Player") && allowDamage) {
            Debug.Log("Contact damage");
            _gameManager.HealthDecr(contactDamage);
            allowDamage = false;
        }
        else {
            collision_check_for_movement = true;
        }

        // if (col.gameObject.CompareTag("End")) {
        //     Destroy(gameObject);
        // }
    }
}