﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameObject Asteroid;
    public GameObject BulletsPowerUp;
    public GameObject HealthPowerUp;
    float RandomNum;
    private const float velX = 0;
    public float velY = -1f;
    Rigidbody2D rb;
    int asteroidHealth = 1;
    bool canAppear = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            int shipHealth = GameObject.Find("Ship").GetComponent<Ship>().shipHealth;
            asteroidHealth -= 1;
            if (asteroidHealth == 0)
            {
                Destroy(gameObject);

                if (Random.Range(0.00f, 1.00f) < 0.25)
                {
                    Instantiate(BulletsPowerUp, transform.position, transform.rotation);
                    canAppear = false;
                    StartCoroutine(NoAppear());
                }
                if (Random.Range(1.00f, 2.00f) < 1.10 && shipHealth < 10 && canAppear)
                {
                    Instantiate(HealthPowerUp, transform.position, transform.rotation);
                }
            }
        }

    }

    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds(1.0f);
        canAppear = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}