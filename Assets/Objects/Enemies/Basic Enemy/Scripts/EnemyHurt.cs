using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHurt : MonoBehaviour
{
    private Animator animator;

    private AudioSource[] audioSources;
    public int enemyHealth = 5;
    public static int level1Enemies = 52;
    private AudioClip explosionSound;
    private AudioClip laserImpactSound;
    private AudioClip fireImpactSound;
    public GameObject enemyExplosion;
    public GameObject enemyFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
        fireImpactSound = audioSources[2].clip;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            enemyHealth -= 1;
            animator.SetTrigger("Damaged");
            audioSources[0].PlayOneShot(laserImpactSound);
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                level1Enemies--;
                ShipShoot.multiplierTimer = 4.0f;
                AudioSource.PlayClipAtPoint(laserImpactSound, new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                if (ShipShoot.multiplier < ShipShoot.maxMultiplier) ShipShoot.multiplier++;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            }
        }
        if (col.gameObject.CompareTag("FireProjectile"))
        {
            enemyHealth -= 2;
            animator.SetTrigger("Damaged");
            audioSources[2].PlayOneShot(fireImpactSound);
            Instantiate(enemyFire, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.1f), transform.rotation);
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                level1Enemies--;
                ShipShoot.multiplierTimer = 4.0f;
                AudioSource.PlayClipAtPoint(fireImpactSound, new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                if (ShipShoot.multiplier < ShipShoot.maxMultiplier) ShipShoot.multiplier++;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            }
        }
    }
}