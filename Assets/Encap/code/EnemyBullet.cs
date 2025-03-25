using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        F16 player = other.GetComponent<F16>();
        if(player != null) {
            player.TakeDamage();
            Destroy(gameObject);
        }
    }
}
