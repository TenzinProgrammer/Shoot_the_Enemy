using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F16 : MonoBehaviour
{
    [SerializeField] private GameObject jet;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioSource shootAudio;
    [SerializeField] private GameObject explosion;
    [SerializeField] private TextMeshProUGUI playerHealthTxt;
    public Rigidbody2D rb;
    private int health = 5;
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(move * speed, moveY * speed);
        if(Input.GetKeyDown(KeyCode.Return)) {
            Shoot();
        }
    }
    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.right * speed;
        shootAudio.Play();
        Destroy(bullet, 3f);
    }
    public void TakeDamage() {
        health--;
        playerHealthTxt.text = "player health : " + health;
        if(health <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            print("player health: " + health);
            Destroy(gameObject);
        }
        print("player health:" + health);
    }
}
