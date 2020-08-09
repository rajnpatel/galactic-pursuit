using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3EnemyMovementRow4 : MonoBehaviour
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
    private Vector2 initialX;
    private Vector2 newTarget;
    private bool settingXpos = true;
    public bool rotatingTopScreen = false;
    public static bool rotationEnabled = false;

    private void Awake()
    {
        initialX.x = transform.position.x;
    }

    private void Start()
    {
        position = transform.position;
        bottomLeftCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0f, 1))).x;
        topRightCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0f, 1))).x;

        if (Level3EnemyHurt.level3Enemies > 31)
        {
            target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .85f, 1))).y;
            topLeftCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .85f, 1))).y;
            bottomRightCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0, .625f, 1))).y;
            StartCoroutine(delayRotation());
        }
        else
        {
            position.x = (Camera.main.ViewportToWorldPoint(new Vector3(1.5f, 0, 1))).x;
            target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .3f, 1))).y;
            topLeftCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .55f, 1))).y;
            bottomRightCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0, .3f, 1))).y;
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
        if (Level3EnemyHurt.level3Enemies < 73 && rotatingTopScreen)
        {
            if (position.x >= bottomLeftCorner.x && position.y == bottomRightCorner.y && !settingPosition)
            {
                position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == bottomLeftCorner.x && !settingPosition)
            {
                position.y = Mathf.MoveTowards(transform.position.y, topLeftCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.y == topLeftCorner.y && !settingPosition)
            {
                position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == topRightCorner.x && !settingPosition)
            {
                position.y = Mathf.MoveTowards(transform.position.y, bottomRightCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
        }
        if (Level3EnemyHurt.level3Enemies < 32 && !rotatingTopScreen)
        {
            if (position.y == target.y && settingXpos)
            {
                settingPosition = false;
                position.x = Mathf.MoveTowards(transform.position.x, initialX.x, Time.deltaTime * speed);
                transform.position = position;
                if (position.x == initialX.x)
                {
                    settingXpos = false;
                }
            }
            if (!settingXpos && !rotatingTopScreen && rotationEnabled)
            {
                if (position.x >= bottomLeftCorner.x && position.y == bottomRightCorner.y && !settingPosition)
                {
                    position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
                    transform.position = position;
                }
                if (position.x == bottomLeftCorner.x && !settingPosition)
                {
                    position.y = Mathf.MoveTowards(transform.position.y, topLeftCorner.y, Time.deltaTime * rotationSpeed);
                    transform.position = position;
                }
                if (position.y == topLeftCorner.y && !settingPosition)
                {
                    position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
                    transform.position = position;
                }
                if (position.x == topRightCorner.x && !settingPosition)
                {
                    position.y = Mathf.MoveTowards(transform.position.y, bottomRightCorner.y, Time.deltaTime * rotationSpeed);
                    transform.position = position;
                }
            }
        }
    }

    public IEnumerator delayRotation()
    {
        //yield return new WaitForSeconds(1.3f);
        yield return new WaitForSeconds(2f);
        settingPosition = false;
        rotatingTopScreen = true;
    }
    public IEnumerator delayRotation2()
    {
        yield return new WaitForSeconds(1.6f);
        settingPosition = false;
    }
    public IEnumerator canRotate()
    {
        yield return new WaitForSeconds(3f);
        rotationEnabled = true;
    }
}