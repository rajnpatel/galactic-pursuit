using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemyWaves : MonoBehaviour
{
    public GameObject level2EnemyRow1;
    public GameObject level2EnemyRow2;
    public GameObject level2EnemyRow2Outer;
    public GameObject level2EnemyRow3Outer;
    public GameObject level2EnemyRow3;
    public GameObject level2EnemyRow4;
    public GameObject boss;
    public GameObject bossTwin;
    public bool canInstantiateWave2 = true;
    public bool canInstantiateWave3 = true;
    public bool canInstantiateWave4 = true;
    public bool canInstantiateboss = true;
    void Start()
    {
        StartCoroutine(instantiateEnemiesWave1());
    }

    void Update()
    {
        if (Level2EnemyHurt.level2Enemies == 62 && canInstantiateWave2)
        {
            canInstantiateWave2 = false;
            StartCoroutine(instantiateEnemiesWave2());
        }
        if (Level2EnemyHurt.level2Enemies == 42 && canInstantiateWave3)
        {
            canInstantiateWave3 = false;
            StartCoroutine(instantiateEnemiesWave3());
        }
        if (Level2EnemyHurt.level2Enemies == 22 && canInstantiateWave4)
        {
            canInstantiateWave4 = false;
            StartCoroutine(instantiateEnemiesWave4());
        }
        if (Level2EnemyHurt.level2Enemies == 2 && canInstantiateboss)
        {
            StartCoroutine(instantiateBoss());
            canInstantiateboss = false;
        }
    }

    public IEnumerator instantiateEnemiesWave1()
    {
        yield return new WaitForSeconds(3.0f);

        float xCoordinateColumn1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.10f, 0f, 1))).x;
        float xCoordinateColumn2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.30f, 0f, 1))).x;
        float xCoordinateColumn3 = (Camera.main.ViewportToWorldPoint(new Vector3(0.50f, 0f, 1))).x;
        float xCoordinateColumn4 = (Camera.main.ViewportToWorldPoint(new Vector3(0.70f, 0f, 1))).x;
        float xCoordinateColumn5 = (Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0f, 1))).x;

        float yCoordinateRow1 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.35f, 1))).y;
        float yCoordinateRow2 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.275f, 1))).y;
        float yCoordinateRow3 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.2f, 1))).y;
        float yCoordinateRow4 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.125f, 1))).y;

        Vector2 spawnPosition1 = new Vector2(xCoordinateColumn1, yCoordinateRow1);
        Vector2 spawnPosition2 = new Vector2(xCoordinateColumn2, yCoordinateRow1);
        Vector2 spawnPosition3 = new Vector2(xCoordinateColumn3, yCoordinateRow1);
        Vector2 spawnPosition4 = new Vector2(xCoordinateColumn4, yCoordinateRow1);
        Vector2 spawnPosition5 = new Vector2(xCoordinateColumn5, yCoordinateRow1);
        Vector2 spawnPosition6 = new Vector2(xCoordinateColumn1, yCoordinateRow2);
        Vector2 spawnPosition7 = new Vector2(xCoordinateColumn2, yCoordinateRow2);
        Vector2 spawnPosition8 = new Vector2(xCoordinateColumn3, yCoordinateRow2);
        Vector2 spawnPosition9 = new Vector2(xCoordinateColumn4, yCoordinateRow2);
        Vector2 spawnPosition10 = new Vector2(xCoordinateColumn5, yCoordinateRow2);
        Vector2 spawnPosition11 = new Vector2(xCoordinateColumn1, yCoordinateRow3);
        Vector2 spawnPosition12 = new Vector2(xCoordinateColumn2, yCoordinateRow3);
        Vector2 spawnPosition13 = new Vector2(xCoordinateColumn3, yCoordinateRow3);
        Vector2 spawnPosition14 = new Vector2(xCoordinateColumn4, yCoordinateRow3);
        Vector2 spawnPosition15 = new Vector2(xCoordinateColumn5, yCoordinateRow3);
        Vector2 spawnPosition16 = new Vector2(xCoordinateColumn1, yCoordinateRow4);
        Vector2 spawnPosition17 = new Vector2(xCoordinateColumn2, yCoordinateRow4);
        Vector2 spawnPosition18 = new Vector2(xCoordinateColumn3, yCoordinateRow4);
        Vector2 spawnPosition19 = new Vector2(xCoordinateColumn4, yCoordinateRow4);
        Vector2 spawnPosition20 = new Vector2(xCoordinateColumn5, yCoordinateRow4);

        /*Instantiate(level2EnemyRow1, spawnPosition1, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition2, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition3, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition4, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition5, transform.rotation);*/
        Instantiate(level2EnemyRow2Outer, spawnPosition6, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition7, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition8, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition9, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition10, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition11, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition12, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition13, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition14, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition15, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition16, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition17, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition18, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition19, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition20, transform.rotation);
    }
    public IEnumerator instantiateEnemiesWave2()
    {

        yield return new WaitForSeconds(1.0f);

        float xCoordinateColumn1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.10f, 0f, 1))).x;
        float xCoordinateColumn2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.30f, 0f, 1))).x;
        float xCoordinateColumn3 = (Camera.main.ViewportToWorldPoint(new Vector3(0.50f, 0f, 1))).x;
        float xCoordinateColumn4 = (Camera.main.ViewportToWorldPoint(new Vector3(0.70f, 0f, 1))).x;
        float xCoordinateColumn5 = (Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0f, 1))).x;

        float yCoordinateRow1 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.35f, 1))).y;
        float yCoordinateRow2 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.275f, 1))).y;
        float yCoordinateRow3 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.2f, 1))).y;
        float yCoordinateRow4 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.125f, 1))).y;

        Vector2 spawnPosition1 = new Vector2(xCoordinateColumn1, yCoordinateRow1);
        Vector2 spawnPosition2 = new Vector2(xCoordinateColumn2, yCoordinateRow1);
        Vector2 spawnPosition3 = new Vector2(xCoordinateColumn3, yCoordinateRow1);
        Vector2 spawnPosition4 = new Vector2(xCoordinateColumn4, yCoordinateRow1);
        Vector2 spawnPosition5 = new Vector2(xCoordinateColumn5, yCoordinateRow1);
        Vector2 spawnPosition6 = new Vector2(xCoordinateColumn1, yCoordinateRow2);
        Vector2 spawnPosition7 = new Vector2(xCoordinateColumn2, yCoordinateRow2);
        Vector2 spawnPosition8 = new Vector2(xCoordinateColumn3, yCoordinateRow2);
        Vector2 spawnPosition9 = new Vector2(xCoordinateColumn4, yCoordinateRow2);
        Vector2 spawnPosition10 = new Vector2(xCoordinateColumn5, yCoordinateRow2);
        Vector2 spawnPosition11 = new Vector2(xCoordinateColumn1, yCoordinateRow3);
        Vector2 spawnPosition12 = new Vector2(xCoordinateColumn2, yCoordinateRow3);
        Vector2 spawnPosition13 = new Vector2(xCoordinateColumn3, yCoordinateRow3);
        Vector2 spawnPosition14 = new Vector2(xCoordinateColumn4, yCoordinateRow3);
        Vector2 spawnPosition15 = new Vector2(xCoordinateColumn5, yCoordinateRow3);
        Vector2 spawnPosition16 = new Vector2(xCoordinateColumn1, yCoordinateRow4);
        Vector2 spawnPosition17 = new Vector2(xCoordinateColumn2, yCoordinateRow4);
        Vector2 spawnPosition18 = new Vector2(xCoordinateColumn3, yCoordinateRow4);
        Vector2 spawnPosition19 = new Vector2(xCoordinateColumn4, yCoordinateRow4);
        Vector2 spawnPosition20 = new Vector2(xCoordinateColumn5, yCoordinateRow4);

        Instantiate(level2EnemyRow1, spawnPosition1, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition2, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition3, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition4, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition5, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition6, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition7, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition8, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition9, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition10, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition11, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition12, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition13, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition14, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition15, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition16, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition17, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition18, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition19, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition20, transform.rotation);
    }

    public IEnumerator instantiateEnemiesWave3()
    {
        yield return new WaitForSeconds(1.0f);

        float xCoordinateColumn1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.10f, 0f, 1))).x;
        float xCoordinateColumn2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.30f, 0f, 1))).x;
        float xCoordinateColumn3 = (Camera.main.ViewportToWorldPoint(new Vector3(0.50f, 0f, 1))).x;
        float xCoordinateColumn4 = (Camera.main.ViewportToWorldPoint(new Vector3(0.70f, 0f, 1))).x;
        float xCoordinateColumn5 = (Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0f, 1))).x;

        float yCoordinateRow1 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.35f, 1))).y;
        float yCoordinateRow2 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.275f, 1))).y;
        float yCoordinateRow3 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.2f, 1))).y;
        float yCoordinateRow4 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.125f, 1))).y;

        Vector2 spawnPosition1 = new Vector2(xCoordinateColumn1, yCoordinateRow1);
        Vector2 spawnPosition2 = new Vector2(xCoordinateColumn2, yCoordinateRow1);
        Vector2 spawnPosition3 = new Vector2(xCoordinateColumn3, yCoordinateRow1);
        Vector2 spawnPosition4 = new Vector2(xCoordinateColumn4, yCoordinateRow1);
        Vector2 spawnPosition5 = new Vector2(xCoordinateColumn5, yCoordinateRow1);
        Vector2 spawnPosition6 = new Vector2(xCoordinateColumn1, yCoordinateRow2);
        Vector2 spawnPosition7 = new Vector2(xCoordinateColumn2, yCoordinateRow2);
        Vector2 spawnPosition8 = new Vector2(xCoordinateColumn3, yCoordinateRow2);
        Vector2 spawnPosition9 = new Vector2(xCoordinateColumn4, yCoordinateRow2);
        Vector2 spawnPosition10 = new Vector2(xCoordinateColumn5, yCoordinateRow2);
        Vector2 spawnPosition11 = new Vector2(xCoordinateColumn1, yCoordinateRow3);
        Vector2 spawnPosition12 = new Vector2(xCoordinateColumn2, yCoordinateRow3);
        Vector2 spawnPosition13 = new Vector2(xCoordinateColumn3, yCoordinateRow3);
        Vector2 spawnPosition14 = new Vector2(xCoordinateColumn4, yCoordinateRow3);
        Vector2 spawnPosition15 = new Vector2(xCoordinateColumn5, yCoordinateRow3);
        Vector2 spawnPosition16 = new Vector2(xCoordinateColumn1, yCoordinateRow4);
        Vector2 spawnPosition17 = new Vector2(xCoordinateColumn2, yCoordinateRow4);
        Vector2 spawnPosition18 = new Vector2(xCoordinateColumn3, yCoordinateRow4);
        Vector2 spawnPosition19 = new Vector2(xCoordinateColumn4, yCoordinateRow4);
        Vector2 spawnPosition20 = new Vector2(xCoordinateColumn5, yCoordinateRow4);

        Instantiate(level2EnemyRow1, spawnPosition1, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition2, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition3, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition4, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition5, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition6, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition7, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition8, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition9, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition10, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition11, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition12, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition13, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition14, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition15, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition16, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition17, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition18, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition19, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition20, transform.rotation);
    }

    public IEnumerator instantiateEnemiesWave4()
    {

        yield return new WaitForSeconds(1.0f);

        float xCoordinateColumn1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.10f, 0f, 1))).x;
        float xCoordinateColumn2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.30f, 0f, 1))).x;
        float xCoordinateColumn3 = (Camera.main.ViewportToWorldPoint(new Vector3(0.50f, 0f, 1))).x;
        float xCoordinateColumn4 = (Camera.main.ViewportToWorldPoint(new Vector3(0.70f, 0f, 1))).x;
        float xCoordinateColumn5 = (Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0f, 1))).x;

        float yCoordinateRow1 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.35f, 1))).y;
        float yCoordinateRow2 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.275f, 1))).y;
        float yCoordinateRow3 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.2f, 1))).y;
        float yCoordinateRow4 = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 1.125f, 1))).y;

        Vector2 spawnPosition1 = new Vector2(xCoordinateColumn1, yCoordinateRow1);
        Vector2 spawnPosition2 = new Vector2(xCoordinateColumn2, yCoordinateRow1);
        Vector2 spawnPosition3 = new Vector2(xCoordinateColumn3, yCoordinateRow1);
        Vector2 spawnPosition4 = new Vector2(xCoordinateColumn4, yCoordinateRow1);
        Vector2 spawnPosition5 = new Vector2(xCoordinateColumn5, yCoordinateRow1);
        Vector2 spawnPosition6 = new Vector2(xCoordinateColumn1, yCoordinateRow2);
        Vector2 spawnPosition7 = new Vector2(xCoordinateColumn2, yCoordinateRow2);
        Vector2 spawnPosition8 = new Vector2(xCoordinateColumn3, yCoordinateRow2);
        Vector2 spawnPosition9 = new Vector2(xCoordinateColumn4, yCoordinateRow2);
        Vector2 spawnPosition10 = new Vector2(xCoordinateColumn5, yCoordinateRow2);
        Vector2 spawnPosition11 = new Vector2(xCoordinateColumn1, yCoordinateRow3);
        Vector2 spawnPosition12 = new Vector2(xCoordinateColumn2, yCoordinateRow3);
        Vector2 spawnPosition13 = new Vector2(xCoordinateColumn3, yCoordinateRow3);
        Vector2 spawnPosition14 = new Vector2(xCoordinateColumn4, yCoordinateRow3);
        Vector2 spawnPosition15 = new Vector2(xCoordinateColumn5, yCoordinateRow3);
        Vector2 spawnPosition16 = new Vector2(xCoordinateColumn1, yCoordinateRow4);
        Vector2 spawnPosition17 = new Vector2(xCoordinateColumn2, yCoordinateRow4);
        Vector2 spawnPosition18 = new Vector2(xCoordinateColumn3, yCoordinateRow4);
        Vector2 spawnPosition19 = new Vector2(xCoordinateColumn4, yCoordinateRow4);
        Vector2 spawnPosition20 = new Vector2(xCoordinateColumn5, yCoordinateRow4);

        Instantiate(level2EnemyRow1, spawnPosition1, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition2, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition3, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition4, transform.rotation);
        Instantiate(level2EnemyRow1, spawnPosition5, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition6, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition7, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition8, transform.rotation);
        Instantiate(level2EnemyRow2, spawnPosition9, transform.rotation);
        Instantiate(level2EnemyRow2Outer, spawnPosition10, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition11, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition12, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition13, transform.rotation);
        Instantiate(level2EnemyRow3, spawnPosition14, transform.rotation);
        Instantiate(level2EnemyRow3Outer, spawnPosition15, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition16, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition17, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition18, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition19, transform.rotation);
        Instantiate(level2EnemyRow4, spawnPosition20, transform.rotation);
    }

    public IEnumerator instantiateBoss()
    {
        yield return new WaitForSeconds(1.0f);
        float xCoordinate1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0f, 1))).x;
        float xCoordinate2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0f, 1))).x;
        float yCoordinate = (Camera.main.ViewportToWorldPoint(new Vector3(0, 1.3f, 0))).y;
        Vector2 spawnPosition1 = new Vector2(xCoordinate1, yCoordinate);
        Vector2 spawnPosition2 = new Vector2(xCoordinate2, yCoordinate);
        BossMovement.settingPosition = true;
        BossMovement.column1 = false;
        BossMovement.column2 = true;
        BossMovement.column3 = false;
        BossMovement.column4 = false;
        BossMovement.column5 = false;
        Instantiate(boss, spawnPosition1, transform.rotation);
        Instantiate(bossTwin, spawnPosition2, transform.rotation);
        //rememeber when instantiating new instances of boss to change BossMovement.settingPosition to true
    }
}
