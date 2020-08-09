using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public string currentScene;
    public string sceneName;
    public Animator transitionAnim;
    private bool transitionEndGameToMainMenu = true;
    private void Update()
    {
        if (Input.GetMouseButton(0) && currentScene == "Main Menu" || Input.GetMouseButton(0) && currentScene == "Game Over")
        {
            StartCoroutine(LoadScene());
        }

        if (ShipMovement.transitionToLevel2)
        {
            ShipMovement.transitionToLevel2 = false;
            StartCoroutine(LoadLevel2());
        }

        if (ShipMovement.transitionToLevel3)
        {
            ShipMovement.transitionToLevel3 = false;
            StartCoroutine(LoadLevel3());
        }
        if (ShipMovement.transitionToEndGame)
        {
            ShipMovement.transitionToEndGame = false;
            StartCoroutine(EndGame());
        }
        if (currentScene == "End Game" && transitionEndGameToMainMenu)
        {
            transitionEndGameToMainMenu = false;
            StartCoroutine(EndGameToMainMenu());
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1.0f)
            {
                Lives.respawning = true;
                ShipShoot.weapon3 = false;
                ShipShoot.weapon2 = true;
                ShipShoot.weapon1 = false;
                ShipShoot.canFire = true;
                Time.timeScale = 5.0f;
            }
            else
            {
                Lives.respawning = false;
                Time.timeScale = 1.0f;
            }
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
        ShipMovement.level2Transition = false;
        ShipMovement.level2EndMovement = true;
        ShipMovement.endGameTransition = false;
        ShipMovement.endGameMovement = true;
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
        Level2EnemyHurt.level2Enemies = 77;
        Level3EnemyHurt.level3Enemies = 92;
        Level3EnemyMovementRow4.rotationEnabled = false;
        Level3EnemyMovementRow1.rotationEnabled = false;
        Level3EnemyMovementRow3.firstShield = true;
        Level3EnemyMovementRow3.initialOffScreenMove = true;
        Level3EnemyMovementRow3.secondOffScreenMove = false;
        Level3EnemyMovementRow2.initialOffScreenMove = true;
        Level3EnemyMovementRow2.secondOffScreenMove = false;
        BossMovement.column1 = false;
        BossMovement.column2 = false;
        BossMovement.column3 = true;
        BossMovement.column4 = false;
        BossMovement.column5 = false;
        BossTwinMovement.twinColumn1 = false;
        BossTwinMovement.twinColumn2 = false;
        BossTwinMovement.twinColumn3 = false;
        BossTwinMovement.twinColumn4 = true;
        BossTwinMovement.twinColumn5 = false;
        BossMovement.settingPosition = true;
        BossTwinMovement.settingPosition = true;
        EnemyShield.shield = true;
        EnemyShield.triggered = false;
        EnemyShield.relocating = false;
        BossMovement.settingPosition = true;
    }

    private IEnumerator LoadLevel2()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        Ship.hasDied = false;
        ShipMovement.movementDisabled = false;
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
    private IEnumerator LoadLevel3()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        Ship.hasDied = false;
        ShipMovement.movementDisabled = false;
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
    private IEnumerator EndGame()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator EndGameToMainMenu()
    {
        yield return new WaitForSeconds(1f);
        transitionAnim.SetTrigger("End");
        SceneManager.LoadScene("Main Menu");
    }
}