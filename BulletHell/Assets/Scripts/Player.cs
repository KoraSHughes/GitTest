using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int speed = 10;
    int health = 100;
    int bulletSpeed = 300;
    float time = 0f;

    public Transform spawnPoint;
    public GameObject bullPrfb;
    public GameObject explosion;
    GameManager _gameManager;
    Rigidbody2D _rigidbody2D;

    public AudioClip shootSfx;
    public AudioClip dmgSfx;
    public AudioClip deathSfx;
    AudioSource _audioSource;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float xVeloc = Input.GetAxis("Horizontal") * speed;
        float yVeloc = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xVeloc, yVeloc);

        if (health <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(deathSfx);
            Destroy(gameObject);
        }

        if (time > 0f) {
            time -= Time.deltaTime;
        }

        if (Input.GetButton("Jump") && time <= 0) {
            GameObject newBull = Instantiate(bullPrfb, spawnPoint.position, Quaternion.identity);
            newBull.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
            time = 0.3f;
            _audioSource.PlayOneShot(shootSfx);
        }
    }

    public void DecrHealth() {
        _audioSource.PlayOneShot(dmgSfx);
        health -= 20;
        _gameManager.HealthDecr(20);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Enemy(Clone)") {
            DecrHealth();
        }
    }
}
