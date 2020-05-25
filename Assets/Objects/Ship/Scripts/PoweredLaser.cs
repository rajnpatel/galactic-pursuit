using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoweredLaser : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float velX = 0;
    private float speed = 60f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velX, speed);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BasicEnemy")
        || col.gameObject.CompareTag("Asteroid")) Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
