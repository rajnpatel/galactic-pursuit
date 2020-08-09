using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3EnemyMovementRow3Outer : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private float rotationSpeed = 6f;
    private Vector2 target;
    private Vector2 bottomLeftCorner;
    private Vector2 topLeftCorner;
    private Vector2 topRightCorner;
    private Vector2 bottomRightCorner;
    public bool settingPosition = true;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .775f, 1))).y;
        topLeftCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.85f, 1))).y;
        bottomRightCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0, .625f, 1))).y;
        bottomLeftCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
        topRightCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;
        if (Level3EnemyHurt.level3Enemies < 73)
        {
            StartCoroutine(delayRotation());
        }
    }

    private void Update()
    {
        if (position.y > target.y && settingPosition)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
        /*if (position.y == target.y && settingPosition)
        {
            if (Level3EnemyHurt.level3Enemies > 66)
            {
                StartCoroutine("delayRotation");
            }
            else
            {
                StartCoroutine("delayRotation2");
            }
        }*/
        if (Level3EnemyHurt.level3Enemies < 73)
        {
            if (position.x >= bottomLeftCorner.x && position.y == bottomRightCorner.y && settingPosition == false)
            {
                position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == bottomLeftCorner.x && settingPosition == false)
            {
                position.y = Mathf.MoveTowards(transform.position.y, topLeftCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.y == topLeftCorner.y && settingPosition == false)
            {
                position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == topRightCorner.x && settingPosition == false)
            {
                position.y = Mathf.MoveTowards(transform.position.y, bottomRightCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
        }

    }
    public IEnumerator delayRotation()
    {
        //yield return new WaitForSeconds(1.0f);
        yield return new WaitForSeconds(2f);
        settingPosition = false;
    }
    public IEnumerator delayRotation2()
    {
        yield return new WaitForSeconds(1.5f);
        settingPosition = false;
    }
}