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
                Destroy(gameObject);
                Level1EnemyHurt.level1Enemies--;
                AudioSource.PlayClipAtPoint(laserImpactSound, new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                if (Level1EnemyHurt.level1Enemies == 0)
                {
                    ShipMovement.level1Transition = true;
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
                AudioSource.PlayClipAtPoint(fireImpactSound, new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
                Level1EnemyHurt.level1Enemies--;
                if (Level1EnemyHurt.level1Enemies == 0)
                {
                    ShipMovement.level1Transition = true;
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
                AudioSource.PlayClipAtPoint(poweredLaserImpactSound, new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                Instantiate(bossExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
                Level1EnemyHurt.level1Enemies--;
                if (Level1EnemyHurt.level1Enemies == 0)
                {
                    ShipMovement.level1Transition = true;
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
