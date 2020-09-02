using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsPowerUp : MonoBehaviour
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
            if (!ShipShoot.blueWeapons)
            {
                ShipShoot.blueWeapons = true;
                if (ShipShoot.weapon1)
                {
                    ShipShoot.canShoot = false;
                    ShipShoot.blueCanShoot = true;
                }
                else if (ShipShoot.weapon2)
                {
                    ShipShoot.canFire = false;
                    ShipShoot.blueCanFire = true;
                }
                else if (ShipShoot.weapon3)
                {
                    ShipShoot.canShootPoweredLaser = false;
                    ShipShoot.blueCanShootPoweredLaser = true;
                }
            }
            Asteroid.WeaponsPowerUpInitialSpawn = true;
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}