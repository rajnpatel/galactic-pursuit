using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject EnemyLaser;

    private void Update()
    {
        if (!canShoot) return;
        canShoot = false;
        StartCoroutine(NoFire());
    }

    private IEnumerator NoFire()
    {
        yield return new WaitForSeconds((float)RandomHandler.EnemyRandomShoot());
        Instantiate(EnemyLaser, transform.position, transform.rotation);
        canShoot = true;
    }
}