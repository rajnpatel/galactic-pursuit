using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1EnemyWaves : MonoBehaviour
{
    public GameObject level1EnemyRow1;
    public GameObject level1EnemyRow2;

    public GameObject level1EnemyRow3;

    public GameObject level1EnemyRow4;

    public bool canInstantiate = true;

    void Start()
    {
        StartCoroutine(instantiateEnemies());
    }

    void Update()
    {
        if (EnemyHurt.level1Enemies == 0 && canInstantiate)
        {
            StartCoroutine(instantiateEnemies());
            canInstantiate = false;
        }
    }
    public IEnumerator instantiateEnemies()
    {
        yield return new WaitForSeconds(0.01f);

        float xCoordinateColumn1 = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
        float xCoordinateColumn2 = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
        float xCoordinateColumn3 = (Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f, 1))).x;
        float xCoordinateColumn4 = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
        float xCoordinateColumn5 = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;

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

        Instantiate(level1EnemyRow1, spawnPosition1, transform.rotation);
        Instantiate(level1EnemyRow1, spawnPosition2, transform.rotation);
        Instantiate(level1EnemyRow1, spawnPosition3, transform.rotation);
        Instantiate(level1EnemyRow1, spawnPosition4, transform.rotation);
        Instantiate(level1EnemyRow1, spawnPosition5, transform.rotation);
        Instantiate(level1EnemyRow2, spawnPosition6, transform.rotation);
        Instantiate(level1EnemyRow2, spawnPosition7, transform.rotation);
        Instantiate(level1EnemyRow2, spawnPosition8, transform.rotation);
        Instantiate(level1EnemyRow2, spawnPosition9, transform.rotation);
        Instantiate(level1EnemyRow2, spawnPosition10, transform.rotation);
        Instantiate(level1EnemyRow3, spawnPosition11, transform.rotation);
        Instantiate(level1EnemyRow3, spawnPosition12, transform.rotation);
        Instantiate(level1EnemyRow3, spawnPosition13, transform.rotation);
        Instantiate(level1EnemyRow3, spawnPosition14, transform.rotation);
        Instantiate(level1EnemyRow3, spawnPosition15, transform.rotation);
        Instantiate(level1EnemyRow4, spawnPosition16, transform.rotation);
        Instantiate(level1EnemyRow4, spawnPosition17, transform.rotation);
        Instantiate(level1EnemyRow4, spawnPosition18, transform.rotation);
        Instantiate(level1EnemyRow4, spawnPosition19, transform.rotation);
        Instantiate(level1EnemyRow4, spawnPosition20, transform.rotation);
    }
}
