﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public string currentScene;
    public string sceneName;
    public Animator transitionAnim;
    private void Update()
    {
        if (Input.GetMouseButton(0) && currentScene == "Main Menu" || Input.GetMouseButton(0) && currentScene == "Game Over")
        {
            StartCoroutine(LoadScene());
        }

        if (ShipMovement.transitionToLevel2)
        {
            StartCoroutine(LoadLevel2());
        }
    }

    private IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        ShipMovement.movementDisabled = false;
        ShipMovement.initialMove = true;
        ShipMovement.level1Transition = false;
        ShipMovement.level1EndMovement = true;
        ShipMovement.columnPosition = 3;
        ShipMovement.movingToCenter = true;
        ShipShoot.canShoot = true;
        ShipShoot.canFire = false;
        ShipShoot.weapon1 = true;
        ShipShoot.weapon2 = false;
        ShipShoot.weapon3 = false;
        ShipShoot.allWeaponsDisabled = false;
        Ship.shield = false;
        Ship.hasDied = false;
        Ship.shipHealth = 3;
        Lives.lives = 3;
        Lives.liveTwoRespawn = true;
        Lives.liveOneRespawn = true;
        Level1EnemyHurt.level1Enemies = 73;
        Level2EnemyHurt.level2Enemies = 76;
        BossMovement.settingPosition = true;
    }

    private IEnumerator LoadLevel2()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        Ship.hasDied = false;
        ShipMovement.movementDisabled = false;
        ShipMovement.transitionToLevel2 = false;
        ShipMovement.level1EndMovement = true;
        ShipMovement.initialMove = true;
        if (ShipShoot.weapon1)
        {
            ShipShoot.canShoot = true;
        }
        if (ShipShoot.weapon2)
        {
            ShipShoot.canFire = true;
        }
        if (ShipShoot.weapon3)
        {
            ShipShoot.canShootPoweredLaser = true;
            PoweredLaserMuzzle.canAnimateMuzzle = true;
        }
        if (Ship.shield)
        {
            Shield.shieldCanAppear = true;
        }
    }
}