using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public static float multiplier = 1.0f;

    public static float multiplierTimer = 4.0f;

    public static int minMultiplier = 1;

    public static int maxMultiplier = 5;

    public static bool canShoot = true;
    public AudioSource audioData;
    public GameObject ShipLaser;
    public GameObject FireBeam;
    public static bool canFire = false;
    private float shootDelayTime = 0.2f;
    public static bool weapon1 = true;
    public static bool weapon2 = false;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        multiplierTimer -= Time.deltaTime;
        if (multiplierTimer < 0 && minMultiplier < multiplier)
        {
            multiplier--;
            multiplierTimer = 4.0f;
        }
        shootDelayTime = 0.40f / multiplier;
        if (canShoot && weapon1)
        {
            StartCoroutine(NoShoot());
        }
        canShoot = false;
        if (canFire && weapon2)
        {
            StartCoroutine(NoFire());
        }
        canFire = false;

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BulletsPowerUp"))
        {
            multiplierTimer = 4.0f;
            if (multiplier < maxMultiplier) multiplier++;
        }

        if (col.gameObject.CompareTag("EnemyProjectile") || col.gameObject.CompareTag("BasicEnemy") ||
            col.gameObject.CompareTag("Asteroid"))
        {
            multiplierTimer = 4.0f;
            if (minMultiplier < multiplier) multiplier--;
        }
        if (col.gameObject.CompareTag("FirePowerUp") && weapon2 == false)
        {
            weapon1 = false;
            weapon2 = true;
            canFire = true;
        }
    }

    private IEnumerator NoShoot()
    {
        yield return new WaitForSeconds(.15f);
        Instantiate(ShipLaser, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
        audioData.Play(0);
        canShoot = true;
    }
    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds(.15f);
        Instantiate(FireBeam, new Vector3(transform.position.x - 0.1f, transform.position.y + 1.0f), Quaternion.Euler(0, 0, 92));
        canFire = true;
    }
}