﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerUp : MonoBehaviour
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
            if (Lives.lives < 3)
            {
                Lives.lives++;
                if (Lives.lives == 3)
                {
                    Lives.liveTwoRespawn = true;
                }
                else if (Lives.lives == 2)
                {
                    Lives.liveOneRespawn = true;
                }
            }
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}