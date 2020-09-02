using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level1EnemyHurt : MonoBehaviour
{
    private AudioSource[] audioSources;
    private int enemyHealth = 5;
    public static int level1Enemies = 73;
    private AudioClip explosionSound;
    private AudioClip laserImpactSound;
    private AudioClip fireImpactSound;
    private AudioClip poweredLaserImpactSound;
    public GameObject enemyExplosion;
    public GameObject enemyFire;
    public GameObject blueEnemyFire;
    public bool canAnimate = true;
    public bool enemy1 = true;
    public bool enemy2 = false;
    public Sprite enemyIdle1;
    public Sprite enemyIdle2;
    public Sprite enemyIdle1Hurt;
    public Sprite enemyIdle2Hurt;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
        fireImpactSound = audioSources[2].clip;
        poweredLaserImpactSound = audioSources[3].clip;
    }

    private void Update()
    {
        if (canAnimate)
        {
            canAnimate = false;
            StartCoroutine(enemyAnimate());
        }
    }
    private IEnumerator enemyAnimate()
    {
        yield return new WaitForSeconds(0.5f);
        enemy1 = true;
        enemy2 = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle1;
        yield return new WaitForSeconds(0.5f);
        enemy1 = false;
        enemy2 = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle2;
        canAnimate = true;
    }
    private IEnumerator enemyHurt()
    {
        if (enemy1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle1Hurt;
            yield return new WaitForSeconds(0.05f);
            if (enemy1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle1;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle2Hurt;
            yield return new WaitForSeconds(0.05f);
            if (enemy2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = enemyIdle2;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            enemyHealth -= 1;
            StartCoroutine(enemyHurt());
            audioSources[0].PlayOneShot(laserImpactSound);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.laserSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("FireProjectile"))
        {
            enemyHealth -= 2;
            StartCoroutine(enemyHurt());
            audioSources[2].PlayOneShot(fireImpactSound);
            Instantiate(enemyFire, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.1f), transform.rotation);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.fireSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("PoweredLaser"))
        {
            enemyHealth -= 1;
            StartCoroutine(enemyHurt());
            audioSources[3].PlayOneShot(poweredLaserImpactSound);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.poweredLaserSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("BlueShipLaser"))
        {
            enemyHealth -= 2;
            StartCoroutine(enemyHurt());
            audioSources[0].PlayOneShot(laserImpactSound);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.laserSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("BlueFireProjectile"))
        {
            enemyHealth -= 3;
            StartCoroutine(enemyHurt());
            audioSources[2].PlayOneShot(fireImpactSound);
            Instantiate(blueEnemyFire, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.1f), transform.rotation);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.fireSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
        if (col.gameObject.CompareTag("BluePoweredLaser"))
        {
            enemyHealth -= 2;
            StartCoroutine(enemyHurt());
            audioSources[3].PlayOneShot(poweredLaserImpactSound);
            if (enemyHealth <= 0)
            {
                EnemyExplosion.poweredLaserSound = true;
                level1Enemies--;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}