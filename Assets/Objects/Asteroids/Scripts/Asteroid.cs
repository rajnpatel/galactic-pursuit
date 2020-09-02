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
    public GameObject WeaponsPowerUp;
    public GameObject AsteroidExplosion;
    private AudioClip laserImpactSound;
    private readonly float powerUpDelay = .01f;
    private float RandomNum;
    private Rigidbody2D rb;
    public float velY = -3f;
    public GameObject fireResidual;
    public GameObject blueFireResidual;
    public static bool WeaponsPowerUpInitialSpawn = false;

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
        if (col.gameObject.CompareTag("BlueShipLaser"))
        {
            asteroidHealth -= 2;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (col.gameObject.CompareTag("BlueFireProjectile"))
        {
            Instantiate(blueFireResidual, new Vector3(transform.position.x - 0.1f, transform.position.y), transform.rotation);
            asteroidHealth -= 3;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (col.gameObject.CompareTag("BluePoweredLaser"))
        {
            asteroidHealth -= 2;
            audioSources[0].PlayOneShot(laserImpactSound);
        }
        if (asteroidHealth <= 0)
        {
            Instantiate(AsteroidExplosion, new Vector3(transform.position.x, transform.position.y - 0.1f), transform.rotation);
            Destroy(gameObject);

            if (Level3EnemyHurt.level3Enemies < 83 && !WeaponsPowerUpInitialSpawn && canAppear)
            {
                Instantiate(WeaponsPowerUp,
                transform.position,
                transform.rotation);
                canAppear = false;
                StartCoroutine(NoAppear());
                WeaponsPowerUpInitialSpawn = true;
            }
            else if (Level2EnemyHurt.level2Enemies > 63)
            {
                if (Ship.shipHealth != 3)
                {
                    if (Lives.lives == 3)
                    {
                        if (Random.Range(1, 4) == 1 && canAppear)
                        {
                            Debug.Log("Scenario 1, Case 1");
                            Instantiate(LaserPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 4) == 2 && canAppear)
                        {
                            Debug.Log("Scenario 1, Case 2");
                            Instantiate(HealthPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 4) == 3 && canAppear)
                        {
                            Debug.Log("Scenario 1, Case 3");
                            Instantiate(FirePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else
                        {
                            Debug.Log("Scenario 1, Case 4");
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
                            Debug.Log("Scenario 2, Case 1");
                            Instantiate(LaserPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 5) == 2 && canAppear)
                        {
                            Debug.Log("Scenario 2, Case 2");
                            Instantiate(HealthPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 5) == 3 && canAppear)
                        {
                            Debug.Log("Scenario 2, Case 3");
                            Instantiate(FirePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 5) == 4 && canAppear)
                        {
                            Debug.Log("Scenario 2, Case 4");
                            Instantiate(LifePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else
                        {
                            Debug.Log("Scenario 2, Case 5");
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
                            Debug.Log("Scenario 3, Case 1");
                            Instantiate(LaserPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 4) == 2 && canAppear)
                        {
                            Debug.Log("Scenario 3, Case 2");
                            Instantiate(FirePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 4) == 3 && canAppear)
                        {
                            Debug.Log("Scenario 3, Case 3");
                            Instantiate(LifePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else
                        {
                            Debug.Log("Scenario 3, Case 4");
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
                            Debug.Log("Scenario 4, Case 1");
                            Instantiate(LaserPowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else if (Random.Range(1, 3) == 2 && canAppear)
                        {
                            Debug.Log("Scenario 4, Case 2");
                            Instantiate(FirePowerUp,
                                transform.position,
                                transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                        else
                        {
                            Debug.Log("Scenario 4, Case 3");
                            Instantiate(ShieldPowerUp,
                            transform.position,
                            transform.rotation);
                            canAppear = false;
                            StartCoroutine(NoAppear());
                        }
                    }
                }
            }
            else if (Level2EnemyHurt.level2Enemies < 63)
            {
                {
                    if (Ship.shipHealth != 3)
                    {
                        if (Lives.lives == 3)
                        {
                            if (Random.Range(1, 5) == 1 && canAppear)
                            {
                                Debug.Log("Scenario 5, Case 1");
                                Instantiate(LaserPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 2 && canAppear)
                            {
                                Debug.Log("Scenario 5, Case 2");
                                Instantiate(HealthPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 3 && canAppear)
                            {
                                Debug.Log("Scenario 5, Case 3");
                                Instantiate(FirePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 4 && canAppear)
                            {
                                Debug.Log("Scenario 5, Case 4");
                                Instantiate(WeaponsPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else
                            {
                                Debug.Log("Scenario 5, Case 5");
                                Instantiate(ShieldPowerUp,
                                transform.position,
                                transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                        }
                        else if (Lives.lives != 3)
                        {
                            if (Random.Range(1, 6) == 1 && canAppear)
                            {
                                Debug.Log("Scenario 6, Case 1");
                                Instantiate(LaserPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 6) == 2 && canAppear)
                            {
                                Debug.Log("Scenario 6, Case 2");
                                Instantiate(HealthPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 6) == 3 && canAppear)
                            {
                                Debug.Log("Scenario 6, Case 3");
                                Instantiate(FirePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 6) == 4 && canAppear)
                            {
                                Debug.Log("Scenario 6, Case 4");
                                Instantiate(LifePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 6) == 5 && canAppear)
                            {
                                Debug.Log("Scenario 6, Case 5");
                                Instantiate(WeaponsPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else
                            {
                                Debug.Log("Scenario 6, Case 6");
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
                            if (Random.Range(1, 5) == 1 && canAppear)
                            {
                                Debug.Log("Scenario 7, Case 1");
                                Instantiate(LaserPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 2 && canAppear)
                            {
                                Debug.Log("Scenario 7, Case 2");
                                Instantiate(FirePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 3 && canAppear)
                            {
                                Debug.Log("Scenario 7, Case 3");
                                Instantiate(LifePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 5) == 4 && canAppear)
                            {
                                Debug.Log("Scenario 7, Case 4");
                                Instantiate(WeaponsPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else
                            {
                                Debug.Log("Scenario 7, Case 5");
                                Instantiate(ShieldPowerUp,
                                transform.position,
                                transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                        }
                        else if (Lives.lives == 3)
                        {
                            if (Random.Range(1, 4) == 1 && canAppear)
                            {
                                Debug.Log("Scenario 8, Case 1");
                                Instantiate(LaserPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 4) == 2 && canAppear)
                            {
                                Debug.Log("Scenario 8, Case 2");
                                Instantiate(FirePowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else if (Random.Range(1, 4) == 3 && canAppear)
                            {
                                Debug.Log("Scenario 8, Case 3");
                                Instantiate(WeaponsPowerUp,
                                    transform.position,
                                    transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                            else
                            {
                                Debug.Log("Scenario 8, Case 4");
                                Instantiate(ShieldPowerUp,
                                transform.position,
                                transform.rotation);
                                canAppear = false;
                                StartCoroutine(NoAppear());
                            }
                        }
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