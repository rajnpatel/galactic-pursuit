using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private Vector2 target;
    private int health = 150;
    public Sprite shieldNormal;
    public Sprite shieldHurt;
    public static bool shield = true;
    public static bool triggered = false;
    public static bool relocating = false;
    private AudioSource[] audioSources;
    private AudioClip laserImpactSound;
    private AudioClip fireImpactSound;
    private AudioClip poweredLaserImpactSound;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .7375f, 1))).y;

        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        poweredLaserImpactSound = audioSources[1].clip;
        fireImpactSound = audioSources[2].clip;
    }
    void Update()
    {
        if (position.y > target.y)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            audioSources[0].PlayOneShot(laserImpactSound);
            StartCoroutine(shieldDamaged());
            health--;
        }
        else if (col.gameObject.CompareTag("PoweredLaser"))
        {
            audioSources[1].PlayOneShot(poweredLaserImpactSound);
            StartCoroutine(shieldDamaged());
            health--;
        }
        else if (col.gameObject.CompareTag("FireProjectile"))
        {
            audioSources[2].PlayOneShot(fireImpactSound);
            StartCoroutine(shieldDamaged());
            health -= 2;
        }
        if (health <= 0)
        {
            shield = false;

            if (Level3EnemyHurt.level3Enemies > 45)
            {
                triggered = true;
            }
            else
            {
                relocating = true;
            }
            Destroy(gameObject);
        }
    }
    public IEnumerator shieldDamaged()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldHurt;
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<SpriteRenderer>().sprite = shieldNormal;
    }
}
