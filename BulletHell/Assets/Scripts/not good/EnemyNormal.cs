// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // Middle enemy type with three variants that shoots laser
// // Red, Green, Blue enemy
// // Elemental, have to match the attack with respective enemy type


// [RequireComponent(typeof(Rigidbody2D))]
// public class EnemyNormal: Enemy {

//     public GameObject Laser;
//     public float normal_speed_x = 30f;
//     public float normal_speed_y = 0f;
//     public int normal_health = 50;
//     public int normal_pointVal = 10;
//     public float normal_attackInterval = 3.0f;
//     private string variant = "Red";

//     void Start() {
//         base.Start();    
//         speed_x = normal_speed_x;
//         speed_y = normal_speed_y;
//         health = normal_health;
//         pointVal = normal_pointVal;
//         attackInterval = normal_attackInterval;
//     }

//     void Update() {
//         // check and handle death...
//         check_and_handle_death();

//         // handle movement behavior...
//         handle_movement();

//         // handle attack behavior...
//         secSinceLastAttack += Time.deltaTime;
//         if (secSinceLastAttack >= attackInterval)
//         {
//             attack();
//             secSinceLastAttack = 0f;
//         }
//     }

//     // override basic attack method with LAZERS
//     void attack()
//     {
//         Debug.Log("Attacking (Normal)...");
//     }
// }
 