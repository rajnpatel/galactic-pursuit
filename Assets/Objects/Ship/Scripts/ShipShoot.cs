using System.Collections;
using UnityEngine;
public class ShipShoot : MonoBehaviour
{
    private AudioSource audioData;
    public GameObject ShipLaser;
    public GameObject FireProjectile;
    public GameObject PoweredLaser;
    public GameObject BlueShipLaser;
    public GameObject BlueFireProjectile;
    public GameObject BluePoweredLaser;
    public GameObject PoweredLaserMuzzle;
    public static bool canShoot = true;
    public static bool canFire = false;
    public static bool canShootPoweredLaser = false;
    public static bool blueCanShoot = false;
    public static bool blueCanFire = false;
    public static bool blueCanShootPoweredLaser = false;
    public static bool weapon1 = true;
    public static bool weapon2 = false;
    public static bool weapon3 = false;
    public static bool allWeaponsDisabled = false;
    public static bool blueWeapons = false;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        if (weapon3)
        {
            StartCoroutine(delayInstantiate());
        }
    }
    public IEnumerator delayInstantiate()
    {
        //note: coroutine needed as without it, muzzle instantiates at -1 on z axis and therefore
        //does not show up in the game
        yield return new WaitForSeconds(0.1f);
        Instantiate(PoweredLaserMuzzle, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
    }
    private void Update()
    {
        if (!blueWeapons)
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
        else if (blueWeapons)
        {
            if (blueCanShoot && weapon1 && !allWeaponsDisabled)
            {
                StartCoroutine(BlueNoShoot());
            }
            blueCanShoot = false;
            if (blueCanFire && weapon2 && !allWeaponsDisabled)
            {
                StartCoroutine(BlueNoFire());
            }
            blueCanFire = false;
            if (blueCanShootPoweredLaser && weapon3 && !allWeaponsDisabled)
            {
                StartCoroutine(BlueNoShootPoweredLaser());
            }
            blueCanShootPoweredLaser = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("FirePowerUp") && weapon2 == false)
        {
            weapon1 = false;
            weapon2 = true;
            weapon3 = false;
            canFire = true;
            if (blueWeapons)
            {
                blueCanFire = true;
            }
        }
        if (col.gameObject.CompareTag("LaserPowerUp") && weapon3 == false)
        {
            Instantiate(PoweredLaserMuzzle, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
            weapon1 = false;
            weapon2 = false;
            weapon3 = true;
            canShootPoweredLaser = true;
            if (blueWeapons)
            {
                blueCanShootPoweredLaser = true;
            }
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
        Instantiate(FireProjectile, new Vector3(transform.position.x - 0.06f, transform.position.y + 0.8f), Quaternion.Euler(0, 0, 92));
        canFire = true;
    }
    private IEnumerator NoShootPoweredLaser()
    {
        yield return new WaitForSeconds(.075f);
        Instantiate(PoweredLaser, new Vector3(transform.position.x - 0.01f, transform.position.y + 0.5f), transform.rotation);
        canShootPoweredLaser = true;
    }

    private IEnumerator BlueNoShoot()
    {
        yield return new WaitForSeconds(.15f);
        Instantiate(BlueShipLaser, new Vector3(transform.position.x, transform.position.y + 0.5f), transform.rotation);
        audioData.Play(0);
        blueCanShoot = true;
    }
    private IEnumerator BlueNoFire()
    {
        yield return new WaitForSeconds(.125f);
        Instantiate(BlueFireProjectile, new Vector3(transform.position.x - 0.06f, transform.position.y + 1.2f), Quaternion.Euler(0, 0, 92));
        blueCanFire = true;
    }
    private IEnumerator BlueNoShootPoweredLaser()
    {
        yield return new WaitForSeconds(.075f);
        Instantiate(BluePoweredLaser, new Vector3(transform.position.x - 0.02f, transform.position.y + 0.5f), transform.rotation);
        blueCanShootPoweredLaser = true;
    }
}