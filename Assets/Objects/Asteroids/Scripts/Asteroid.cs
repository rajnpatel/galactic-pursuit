using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Asteroid : MonoBehaviour
{
    private const float velX = 0;
    private AudioSource[] audioSources;
    private bool canAppear = true;
    private AudioClip explosionSound;
    int asteroidHealth = 7;
    public GameObject LaserPowerUp;
    public GameObject HealthPowerUp;
    public GameObject FirePowerUp;
    public GameObject ShieldPowerUp;
    public GameObject LifePowerUp;
    public GameObject AsteroidExplosion;
    private AudioClip laserImpactSound;
    private readonly float powerUpDelay = .01f;
    private float RandomNum;
    private Rigidbody2D rb;
    public float velY = -3f;
    public GameObject fireResidual;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        audioSources[0].PlayOneShot(laserImpactSound);
    }

    private void Update()
    {
        rb.velocity = new Vector2(velX, velY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            asteroidHealth -= 1;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (col.gameObject.CompareTag("FireProjectile"))
        {
            Instantiate(fireResidual, new Vector3(transform.position.x - 0.1f, transform.position.y), transform.rotation);
            asteroidHealth -= 2;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (col.gameObject.CompareTag("PoweredLaser"))
        {
            asteroidHealth -= 1;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (asteroidHealth <= 0)
        {
            Instantiate(AsteroidExplosion, new Vector3(transform.position.x, transform.position.y - 0.1f), transform.rotation);
            AsteroidAppear.asteroidSound = true;
            Destroy(gameObject);

            if (Ship.shipHealth != 3)
            {
                if (Lives.lives == 3)
                {
                    if (Random.Range(1, 4) == 1 && canAppear)
                    {
                        Instantiate(LaserPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 4) == 2 && canAppear)
                    {
                        Instantiate(HealthPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 4) == 3 && canAppear)
                    {
                        Instantiate(FirePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else
                    {
                        Instantiate(ShieldPowerUp,
                        transform.position,
                        transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                }
                else if (Lives.lives != 3)
                {
                    if (Random.Range(1, 5) == 1 && canAppear)
                    {
                        Instantiate(LaserPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 5) == 2 && canAppear)
                    {
                        Instantiate(HealthPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 5) == 3 && canAppear)
                    {
                        Instantiate(FirePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 5) == 4 && canAppear)
                    {
                        Instantiate(LifePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else
                    {
                        Instantiate(ShieldPowerUp,
                        transform.position,
                        transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                }
            }
            else if (Ship.shipHealth == 3)
            {
                if (Lives.lives != 3)
                {
                    if (Random.Range(1, 4) == 1 && canAppear)
                    {
                        Instantiate(LaserPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 4) == 2 && canAppear)
                    {
                        Instantiate(FirePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 4) == 3 && canAppear)
                    {
                        Instantiate(LifePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else
                    {
                        Instantiate(ShieldPowerUp,
                        transform.position,
                        transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                }
                else if (Lives.lives == 3)
                {
                    if (Random.Range(1, 3) == 1 && canAppear)
                    {
                        Instantiate(LaserPowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else if (Random.Range(1, 3) == 2 && canAppear)
                    {
                        Instantiate(FirePowerUp,
                            transform.position,
                            transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                    else
                    {
                        Instantiate(ShieldPowerUp,
                        transform.position,
                        transform.rotation);
                        canAppear = false;
                        StartCoroutine(NoAppear());
                    }
                }
            }
        }
        if (col.gameObject.CompareTag("Ship") || col.gameObject.CompareTag("Shield")) Destroy(gameObject);

    }

    private IEnumerator NoAppear()
    {
        yield return new WaitForSeconds(powerUpDelay);
        canAppear = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}