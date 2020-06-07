using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwinShoot : MonoBehaviour
{
    private bool canShoot = true;
    public GameObject BossLaser;
    private void Update()
    {
        if (ShipMovement.columnPosition == 1 && BossTwinMovement.twinColumn1 == true || ShipMovement.columnPosition == 2
        && BossTwinMovement.twinColumn2 == true || ShipMovement.columnPosition == 3 && BossTwinMovement.twinColumn3 == true
        || ShipMovement.columnPosition == 4 && BossTwinMovement.twinColumn4 == true || ShipMovement.columnPosition == 5 &&
        BossTwinMovement.twinColumn5 == true && canShoot)
        {
            StartCoroutine(NoFire());
        }
    }

    private IEnumerator NoFire()
    {
        if (canShoot && BossTwinMovement.settingPosition == false)
        {
            canShoot = false;
            Instantiate(BossLaser, transform.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
            canShoot = true;
        }
    }
}
