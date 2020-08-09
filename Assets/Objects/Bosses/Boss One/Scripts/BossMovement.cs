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
    private Vector2 xCoordinateColumn1;
    private Vector2 xCoordinateColumn2;
    private Vector2 xCoordinateColumn3;
    private Vector2 xCoordinateColumn4;
    private Vector2 xCoordinateColumn5;

    void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .825f, 1))).y;
        xCoordinateColumn1.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.10f, 0f, 1))).x;
        xCoordinateColumn2.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.30f, 0f, 1))).x;
        xCoordinateColumn3.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.50f, 0f, 1))).x;
        xCoordinateColumn4.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.70f, 0f, 1))).x;
        xCoordinateColumn5.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0f, 1))).x;
    }

    void Update()
    {


        if (position.y > target.y && settingPosition)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
        if (position.y == target.y && settingPosition)
        {
            StartCoroutine(delayMovement());
        }

        if (position.x >= xCoordinateColumn1.x && movingLeft && column2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn1.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn1.x)
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

        if (position.x >= xCoordinateColumn2.x && movingLeft && column3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn2.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn2.x)
            {
                column1 = false;
                column2 = true;
                column3 = false;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x >= xCoordinateColumn3.x && movingLeft && column4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn3.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn3.x)
            {
                column1 = false;
                column2 = false;
                column3 = true;
                column4 = false;
                column5 = false;
            }
        }
        if (position.x >= xCoordinateColumn4.x && movingLeft && column5 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn4.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn4.x)
            {
                column1 = false;
                column2 = false;
                column3 = false;
                column4 = true;
                column5 = false;
            }
        }

        if (position.x <= xCoordinateColumn2.x && movingRight && column1 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn2.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn2.x)
            {
                column1 = false;
                column2 = true;
                column3 = false;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x <= xCoordinateColumn3.x && movingRight && column2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn3.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn3.x)
            {
                column1 = false;
                column2 = false;
                column3 = true;
                column4 = false;
                column5 = false;
            }
        }

        if (position.x <= xCoordinateColumn4.x && movingRight && column3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn4.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn4.x)
            {
                column1 = false;
                column2 = false;
                column3 = false;
                column4 = true;
                column5 = false;
            }
        }

        if (position.x <= xCoordinateColumn5.x && movingRight && column4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn5.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn5.x)
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
