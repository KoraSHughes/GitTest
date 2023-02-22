// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(Rigidbody2D))]
// public class EnemyEasy: Enemy {

//     public float easy_speed_x = 10f;
//     public float easy_speed_y = 0f;
//     public int easy_health = 50;
//     public int easy_pointVal = 10;
//     public float easy_attackInterval = 3.0f;

//     void Start() {
//         base.Start();    
//         speed_x = easy_speed_x;
//         speed_y = easy_speed_y;
//         health = easy_health;
//         pointVal = easy_pointVal;
//         attackInterval = easy_attackInterval;
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

//     // override basic attack method...
//     void attack()
//     {
//     }
// }
 