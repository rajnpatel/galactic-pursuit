using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurt : MonoBehaviour
{
    private AudioSource[] audioSources;
    public int bossHealth = 100;
    private AudioClip explosionSound;
    private AudioClip laserImpactSound;
    private AudioClip fireImpactSound;
    private AudioClip poweredLaserImpactSound;
    public GameObject bossExplosion;
    public GameObject enemyFire;
    public Sprite boss;
    public Sprite bossHurt;

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
        fireImpactSound = audioSources[2].clip;
        poweredLaserImpactSound = audioSources[3].clip;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            bossHealth -= 1;
            audioSources[0].PlayOneShot(laserImpactSound);
            StartCoroutine(bossHit());
            if (bossHealth <= 0)
            {
                EnemyExplosion.laserSound = true;
                Destroy(gameObject);
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                if (Level1EnemyHurt.level1Enemies == 1)
                {
                    Level1EnemyHurt.level1Enemies--;
                    ShipMovement.level1Transition = true;
                }
                if (Level2EnemyHurt.level2Enemies <= 2)
                {
                    Level2EnemyHurt.level2Enemies--;
                    if (Level2EnemyHurt.level2Enemies == 0)
                    {
                        ShipMovement.level2Transition = true;
                    }
                }
                if (Level3EnemyHurt.level3Enemies <= 11)
                {
                    Level3EnemyHurt.level3Enemies--;
                    if (Level3EnemyHurt.level3Enemies == 0)
                    {
                        ShipMovement.endGameTransition = true;
                    }
                }
            }
        }
        if (col.gameObject.CompareTag("FireProjectile"))
        {
            bossHealth -= 2;
            audioSources[2].PlayOneShot(fireImpactSound);
            StartCoroutine(bossHit());
            Instantiate(enemyFire, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.1f), transform.rotation);
            if (bossHealth <= 0)
            {
                EnemyExplosion.fireSound = true;
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
                if (Level1EnemyHurt.level1Enemies == 1)
                {
                    Level1EnemyHurt.level1Enemies--;
                    ShipMovement.level1Transition = true;
                }
                if (Level2EnemyHurt.level2Enemies <= 2)
                {
                    Level2EnemyHurt.level2Enemies--;
                    if (Level2EnemyHurt.level2Enemies == 0)
                    {
                        ShipMovement.level2Transition = true;
                    }
                }
                if (Level3EnemyHurt.level3Enemies <= 11)
                {
                    Level3EnemyHurt.level3Enemies--;
                    if (Level3EnemyHurt.level3Enemies == 0)
                    {
                        ShipMovement.endGameTransition = true;
                    }
                }
            }
        }
        if (col.gameObject.CompareTag("PoweredLaser"))
        {
            bossHealth -= 1;
            audioSources[3].PlayOneShot(poweredLaserImpactSound);
            StartCoroutine(bossHit());
            if (bossHealth <= 0)
            {
                EnemyExplosion.poweredLaserSound = true;
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
                if (Level1EnemyHurt.level1Enemies == 1)
                {
                    Level1EnemyHurt.level1Enemies--;
                    ShipMovement.level1Transition = true;
                }
                if (Level2EnemyHurt.level2Enemies <= 2)
                {
                    Level2EnemyHurt.level2Enemies--;
                    if (Level2EnemyHurt.level2Enemies == 0)
                    {
                        ShipMovement.level2Transition = true;
                    }
                }
                if (Level3EnemyHurt.level3Enemies <= 11)
                {
                    Level3EnemyHurt.level3Enemies--;
                    if (Level3EnemyHurt.level3Enemies == 0)
                    {
                        ShipMovement.endGameTransition = true;
                    }
                }
            }
        }
    }

    public IEnumerator bossHit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = bossHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = boss;

    }
}
