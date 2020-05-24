using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    Rigidbody2D rb;

    private const float velX = 0;

    private float velY = -3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ship"))
        {
            if (Ship.shield == true)
            {
                Shield.shieldHealth = 5;
                Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag("Ship"))
            {
                if (Ship.shield == false)
                {
                    Shield.shieldHealth = 5;
                    Ship.shield = true;
                    Shield.shieldCanAppear = true;
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}