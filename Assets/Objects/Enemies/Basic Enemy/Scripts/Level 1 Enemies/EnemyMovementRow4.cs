using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRow4 : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private float rotationSpeed = 4f;
    private Vector2 target;
    private Vector2 bottomLeftCorner;
    private Vector2 topLeftCorner;
    private Vector2 topRightCorner;
    private Vector2 bottomRightCorner;
    public bool settingPosition = true;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .85f, 1))).y;
        bottomLeftCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
        topLeftCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.85f, 1))).y;
        topRightCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;
        bottomRightCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0, .625f, 1))).y;
    }

    private void Update()
    {
        if (position.y >= target.y && settingPosition)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
            if (Level1EnemyHurt.level1Enemies <= 21)
            {
                if (position.y == target.y && settingPosition)
                {
                    StartCoroutine("delayRotation");
                }
            }
        }
        if (Level1EnemyHurt.level1Enemies <= 21 && !settingPosition)
        {
            transform.position = position;

            if (position.y == bottomRightCorner.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
            }
            if (position.x == bottomLeftCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, topLeftCorner.y, Time.deltaTime * rotationSpeed);
            }
            if (position.y == topLeftCorner.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
            }
            if (position.x == topRightCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, bottomRightCorner.y, Time.deltaTime * rotationSpeed);
            }
        }
    }

    public IEnumerator delayRotation()
    {
        yield return new WaitForSeconds(1.3f);
        settingPosition = false;
    }

}