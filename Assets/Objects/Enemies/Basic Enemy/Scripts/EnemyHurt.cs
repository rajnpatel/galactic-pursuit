using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyHurt : MonoBehaviour
{
    private Animator animator;

    private AudioSource[] audioSources;
    public int enemyHealth = 5;
    public static int level1Enemies = 20;

    private AudioClip explosionSound;

    private AudioClip laserImpactSound;
    public Sprite explosion0;
    public Sprite explosion1;
    public Sprite explosion2;
    public Sprite explosion3;
    public Sprite explosion4;
    public Sprite explosion5;
    public Sprite explosion6;
    public Sprite explosion7;
    public Sprite explosion8;
    public Sprite explosion9;
    public Sprite explosion10;
    public Sprite explosion11;
    public GameObject enemyExplosion;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            enemyHealth -= 1;
            animator.SetTrigger("Damaged");
            audioSources[0].PlayOneShot(laserImpactSound);
            if (enemyHealth == 0)
            {
                Destroy(gameObject);
                level1Enemies--;
                ShipShoot.multiplierTimer = 4.0f;
                AudioSource.PlayClipAtPoint(laserImpactSound,
                            new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                if (ShipShoot.multiplier < ShipShoot.maxMultiplier) ShipShoot.multiplier++;
                Instantiate(enemyExplosion, new Vector3(transform.position.x, transform.position.y), transform.rotation);
            }
        }
    }
}