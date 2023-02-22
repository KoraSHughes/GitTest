using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject player;

    void Start() {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.name == "Enemy(Clone)") {
            Physics2D.IgnoreCollision(col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            if (player) {
                player.GetComponent<Player>().DecrHealth();
            }
        }
    }
}
