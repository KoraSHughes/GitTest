using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLaser : MonoBehaviour
{

    LineRenderer line;

    public GameObject aimTowards;
    public float laserLength = 2f;
    public float attackDuration = 2f;
    public float cooldownDuration = 1f;
    public float allowDamageInterval = 0.5f;
    public int dmg = 20;
    GameManager _gameManager;



    private float secsSinceAttackStarted = 0f;
    private float secsSinceCooldownStarted;
    private float secsSinceDamagedPlayer = 0f;
    private bool laserOn = false;
    private bool allowDamage = true;

    // Start is called before the first frame update

    void Start()
    {
        secsSinceCooldownStarted = Random.Range(0f, cooldownDuration);
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StopCoroutine("FireLaser");
        StartCoroutine("FireLaser");
        if (laserOn) {
            secsSinceAttackStarted += Time.deltaTime;
            if (secsSinceAttackStarted >= attackDuration) {
                secsSinceAttackStarted = 0f;
                laserOn = false;
            }
        } else {
            secsSinceCooldownStarted += Time.deltaTime;
            if (secsSinceCooldownStarted >= cooldownDuration) {
                secsSinceCooldownStarted = 0f;
                laserOn = true;
            }
        }

        if (!allowDamage) {
            secsSinceDamagedPlayer += Time.deltaTime;
            if (secsSinceDamagedPlayer >= allowDamageInterval) {
                allowDamage = true;
                secsSinceDamagedPlayer = 0f;
            }
        }
    }


    IEnumerator FireLaser()
    {
        line.enabled = true;
        while (laserOn)
        {
            Ray2D ray = new Ray2D(transform.position, transform.forward);
            RaycastHit2D hit;

            line.SetPosition(0, ray.origin);
            line.SetPosition(
                1, 
                Vector2.MoveTowards(ray.origin, aimTowards.transform.position, laserLength)
            );
 
            hit = Physics2D.Raycast(ray.origin, aimTowards.transform.position, laserLength);
            if (hit.collider) {
                if (hit.collider.tag == "Player") {
                    if (allowDamage) {
                        Debug.Log("LaserAttack");
                        _gameManager.handleLaserAttack(dmg);
                        allowDamage = false;
                    }
                }
            }

            yield return null;
        }
        allowDamage = true;
        line.enabled = false;
    }
}
