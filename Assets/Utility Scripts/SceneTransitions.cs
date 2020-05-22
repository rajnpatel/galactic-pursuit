using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public string sceneName;
    public Animator transitionAnim;

    private void Update()
    {
        if (Input.GetMouseButton(0)) StartCoroutine(LoadScene());
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
        Ship.shield = false;
        ShipShoot.multiplier = 1.0f;
        EnemyHurt.level1Enemies = 52;
    }
}