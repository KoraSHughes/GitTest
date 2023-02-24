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
    public int enemyType = 0;
    private int colorCycle = 0;

    int bulletSpeed = -300;
    float time = 0f;

    public int contactDamage = 10;
    public float allowDamageInterval = 1f;

    public string variant = "N/A";
    
    public GameObject[] bullPrfb;

    public Transform spawnPoint;

    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    int timesFired = 0;

    SpriteRenderer _current_sprite;

    GameObject newBull;

    private bool collision_check_for_movement = false;
    private bool allowDamage = true;
    private float secSinceLastDamage = 0f;

    protected void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed_x, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _current_sprite = GetComponent<SpriteRenderer>();
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

        if(time <= 0f)
        {
            if(_current_sprite.sprite.name == "SlimeRed")
            {
                newBull = Instantiate(bullPrfb[0], spawnPoint.position, Quaternion.identity);
            }
            else if(_current_sprite.sprite.name == "SlimeBlue")
            {
                newBull = Instantiate(bullPrfb[1], transform.position, Quaternion.identity);
            }
            else if(_current_sprite.sprite.name == "SlimeGreen")
            {
                newBull = Instantiate(bullPrfb[2], transform.position, Quaternion.identity);
            }
            if(newBull != null)
            {
                newBull.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
                time = Random.Range(0.3f, 1.2f);
                timesFired += 1;
            }
            if(timesFired >= 3)
            {
                time = 3.0f;
            }
        }
        if (!allowDamage) {
            secSinceLastDamage += Time.deltaTime;
            if (secSinceLastDamage >= allowDamageInterval) {
                allowDamage = true;
                secSinceLastDamage = 0f;
            }
            
        }
    }

    private void cycle(){
        if (colorCycle == 0){
            colorCycle = 1;
            _current_sprite.color = new Color (0, 92, 255, 255);
        }
        else if (colorCycle == 1){
            _current_sprite.color = new Color (34, 255, 0, 255);
            colorCycle = 2;
        }
        else {
            _current_sprite.color = new Color (255, 13, 0, 255);
            colorCycle = 0;
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
        if (col.gameObject.CompareTag("Bullet0") && enemyType == 0) {
            health -= 10;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Bullet1") && enemyType == 1) {
            health -= 10;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Bullet2") && enemyType == 2) {
            health -= 10;
            Destroy(col.gameObject);
        }
        else if (enemyType == 4 && ((col.gameObject.CompareTag("Bullet0") && colorCycle == 0) || (col.gameObject.CompareTag("Bullet1") && colorCycle == 1) || (col.gameObject.CompareTag("Bullet2") && colorCycle == 2))){
            cycle();
            health -= 10;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Player") && allowDamage) {
            Debug.Log("Contact damage");
            _gameManager.HealthDecr(contactDamage);
            allowDamage = false;
        }
        else if (col.gameObject.CompareTag("Player") && allowDamage) {
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