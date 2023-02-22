// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

//     // - Higher enemy type that switches colors and has health
//     //     - Zig-zag pattern across screen



// // inherits from EnemyNormal...
// [RequireComponent(typeof(Rigidbody2D))]
// public class EnemyHard: EnemyNormal {

//     public float hard_speed_x = 30f;
//     public float hard_speed_y = 0f;
//     public int hard_health = 50;
//     public int hard_pointVal = 10;
//     public float hard_attackInterval = 3.0f;
//     public string variant = "Red";

//     // Hard enemy switches color randomly between 5 to 10 seconds, by default.
//     public float hard_variantSwitchIntervalUpper = 10.0f;
//     public float hard_variantSwitchIntervalLower = 5.0f;
//     private float variantChangeInterval;
//     private float secSinceLastVariantChange = 0f;

//     void Start() {
//         base.Start();    
//         speed_x = hard_speed_x;
//         speed_y = hard_speed_y;
//         health = hard_health;
//         pointVal = hard_pointVal;
//         attackInterval = hard_attackInterval;

//         // intialize first random variant change interval.
//         variantChangeInterval = Random.Range(hard_variantSwitchIntervalLower, hard_variantSwitchIntervalUpper);
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
//             attack(); // same attack method as normal.
//             secSinceLastAttack = 0f;
//         }

//         // handle random change.
//         secSinceLastVariantChange += Time.deltaTime;
//         if (secSinceLastVariantChange >= variantChangeInterval)
//         {
//             change_variant("Blue");
//             secSinceLastVariantChange = 0f;
//         }
//     }

//     void change_variant(string new_variant)
//     {
//         Debug.Log("Changing variant...");
//         variant = new_variant;

//         // change sprite to match new variant?
//         switch(new_variant)
//         {
//             case "Red":
//                 break;
//             case "Green":
//                 break;
//             case "Blue":
//                 break;
//             default:
//                 break;
//         }
//     }
// }
 