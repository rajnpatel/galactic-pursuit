using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Vector2 leftSide;
    private Vector2 rightSide;
    private Vector2 position;
    private readonly float speed = 4f;
    public bool movingLeft = true;
    public bool movingRight = false;
    public static bool column1 = false;
    public static bool column2 = false;
    public static bool column3 = true;
    public static bool column4 = false;
    public static bool column5 = false;
    private Vector2 target;
    public static bool settingPosition = true;

    void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .775f, 1))).y;
    }

    void Update()
    {
        if (position.y > (Camera.main.ViewportToWorldPoint(new Vector3(0f, .775f, 1))).y && settingPosition)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
        if (position.y == target.y && settingPosition)
        {
            StartCoroutine(delayMovement());
        }

        if (position.x >= -3 && movingLeft && column2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -3, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -3)
            {
                column1 = true;
                column2 = false;
                column3 = false;
                column4 = false;
                column5 = false;
                movingLeft = false;
                movingRight = true;
            }
        }

        if (position.x >= -1.5 && movingLeft && column3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -1.5)
            {
                column1 = false;
                column2 = true;
                column3 = false;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x >= 0 && movingLeft && column4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 0)
            {
                column1 = false;
                column2 = false;
                column3 = true;
                column4 = false;
                column5 = false;
            }
        }
        if (position.x >= 1.5 && movingLeft && column5 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 1.5)
            {
                column1 = false;
                column2 = false;
                column3 = false;
                column4 = true;
                column5 = false;
            }
        }

        if (position.x <= -1.5 && movingRight && column1 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -1.5)
            {
                column1 = false;
                column2 = true;
                column3 = false;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x <= 0 && movingRight && column2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 0)
            {
                column1 = false;
                column2 = false;
                column3 = true;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x <= 1.5 && movingRight && column3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 1.5)
            {
                column1 = false;
                column2 = false;
                column3 = false;
                column4 = true;
                column5 = false;
            }
        }

        if (position.x <= 3 && movingRight && column4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 3, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 3)
            {
                column1 = false;
                column2 = false;
                column3 = false;
                column4 = false;
                column5 = true;
                movingRight = false;
                movingLeft = true;
            }
        }


    }
    public IEnumerator delayMovement()
    {
        yield return new WaitForSeconds(0.5f);
        settingPosition = false;
    }
}
