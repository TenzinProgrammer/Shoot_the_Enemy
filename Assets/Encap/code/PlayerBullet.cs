using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        if(enemy != null) {
            enemy.TakeDamage();
            Destroy(gameObject);
        }
    }
}
