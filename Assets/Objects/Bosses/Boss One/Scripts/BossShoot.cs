using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject BossLaser;
    private void Update()
    {
        if (ShipMovement.columnPosition == 1 && BossMovement.column1 == true || ShipMovement.columnPosition == 2
        && BossMovement.column2 == true || ShipMovement.columnPosition == 3 && BossMovement.column3 == true
        || ShipMovement.columnPosition == 4 && BossMovement.column4 == true || ShipMovement.columnPosition == 5 &&
        BossMovement.column5 == true && canShoot)
        {
            StartCoroutine(NoFire());
        }
    }

    private IEnumerator NoFire()
    {
        if (canShoot && BossMovement.settingPosition == false)
        {
            canShoot = false;
            Instantiate(BossLaser, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            canShoot = true;
        }
    }
}
