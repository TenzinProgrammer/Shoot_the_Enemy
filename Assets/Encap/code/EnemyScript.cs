using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPt;
    [SerializeField] private GameObject explosion;
    [SerializeField] private TextMeshProUGUI enemyCountTxt;
    private List<int> deadEnemyCount = new List<int>();
    private static int deadEnemies = 0;
    private int health = 5;
    private float enemyBulletSpeed = 7f;
    private float speed = 4f;
    private float ShootRate = 1f;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating(nameof(EnemyShoot), 2f, ShootRate);
    }
    void Update() {
        rb.velocity = Vector2.left * speed;
    }
    void EnemyShoot() {
        GameObject enemyBullet = Instantiate(bulletPrefab, bulletSpawnPt.position, Quaternion.identity);
        Rigidbody2D bulletRb = enemyBullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.left * enemyBulletSpeed;
        Destroy(enemyBullet, 3f);
    }
    public void TakeDamage() {
        health--;
        if(health <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            deadEnemies++;
            enemyCountTxt.text = "Enemy Killed : " + deadEnemies;
            print("enemy destroyed. Mission Complete.");
        }
        print("enemy hit, health is : " + health);
    }
}
