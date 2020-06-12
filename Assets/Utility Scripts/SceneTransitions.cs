using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public string currentScene;
    public string sceneName;
    public Animator transitionAnim;

    private void Update()
    {
        if (Input.GetMouseButton(0) && currentScene == "Main Menu")
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
        ShipShoot.canShoot = true;
        ShipShoot.canFire = false;
        ShipShoot.weapon1 = true;
        ShipShoot.weapon2 = false;
        ShipShoot.weapon3 = false;
        Ship.shield = false;
        EnemyHurt.level1Enemies = 73;
    }

    private IEnumerator LoadLevel2()
    {
        transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
        ShipMovement.movementDisabled = false;
        ShipMovement.transitionToLevel2 = false;
        ShipMovement.level1EndMovement = true;
    }
}