using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 500;
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

    public string[] colorArray;  // color variant things
    public Sprite[] spriteArray;
    private SpriteRenderer _sprite_renderer;
    private int currentIndex = 0;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xVeloc = Input.GetAxis("Horizontal") * speed;
        float yVeloc = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xVeloc, yVeloc);

        if (_gameManager.GetHealth() <= 0) {
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
        
        if(Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(SpriteSwap());
        }

        Vector2 pos = transform.position;
        if (transform.position.y > 4.8f){
            pos = new Vector2(transform.position.x, 4.8f);
        }
        else if (transform.position.y < -5){
            pos = new Vector2(transform.position.x, -5);
        }
        if (transform.position.x > 9){
            pos = new Vector2(9, transform.position.y);
        }
        else if (transform.position.x < -9){
            pos = new Vector2(-9, transform.position.y);
        }
        transform.position = pos;
    }

    IEnumerator SpriteSwap()
    {
        currentIndex += 1;
        if(currentIndex >= spriteArray.Length)
        {
            currentIndex = 0;
        }
        changeVariant(currentIndex);
        yield return new WaitForSeconds(2);
    }

    void changeVariant(int newVariantInd)
    {
        _sprite_renderer.sprite = spriteArray[newVariantInd];
    }

    /*private void OnTriggerEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy") {
            DecrHealth();
        }
    }*/
}
