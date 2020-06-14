using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    public AudioSource audioData;
    public GameObject ShipLaser;
    public GameObject FireBeam;
    public GameObject PoweredLaser;
    public GameObject PoweredLaserMuzzle;
    public static bool canShoot = true;
    public static bool canFire = false;
    public static bool canShootPoweredLaser = false;
    public static bool weapon1 = true;
    public static bool weapon2 = false;
    public static bool weapon3 = false;
    public static bool allWeaponsDisabled = false;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (canShoot && weapon1 && !allWeaponsDisabled)
        {
            StartCoroutine(NoShoot());
        }
        canShoot = false;
        if (canFire && weapon2 && !allWeaponsDisabled)
        {
            StartCoroutine(NoFire());
        }
        canFire = false;
        if (canShootPoweredLaser && weapon3 && !allWeaponsDisabled)
        {
            StartCoroutine(NoShootPoweredLaser());
        }
        canShootPoweredLaser = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FirePowerUp") && weapon2 == false)
        {
            weapon1 = false;
            weapon2 = true;
            weapon3 = false;
            canFire = true;
        }
        if (col.gameObject.CompareTag("LaserPowerUp") && weapon3 == false)
        {
            weapon1 = false;
            weapon2 = false;
            weapon3 = true;
            canShootPoweredLaser = true;
            Instantiate(PoweredLaserMuzzle, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
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
        yield return new WaitForSeconds(.125f);
        Instantiate(FireBeam, new Vector3(transform.position.x - 0.06f, transform.position.y + 0.8f), Quaternion.Euler(0, 0, 92));
        canFire = true;
    }
    private IEnumerator NoShootPoweredLaser()
    {
        yield return new WaitForSeconds(.075f);
        Instantiate(PoweredLaser, new Vector3(transform.position.x - 0.01f, transform.position.y + 0.5f), transform.rotation);
        canShootPoweredLaser = true;
    }
}