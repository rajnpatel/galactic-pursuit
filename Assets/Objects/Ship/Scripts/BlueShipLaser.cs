using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueShipLaser : MonoBehaviour
{
    private const float velX = 0;
    private Rigidbody2D rb;
    public float speed = 30f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicEnemy")
        || col.gameObject.CompareTag("Asteroid") || col.gameObject.CompareTag("EnemyShield"))
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}