using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwinMovement : MonoBehaviour
{
    private Vector2 leftSide;
    private Vector2 rightSide;
    private Vector2 position;
    private readonly float speed = 4f;
    public bool movingLeft = false;
    public bool movingRight = true;
    public static bool twinColumn1 = false;
    public static bool twinColumn2 = false;
    public static bool twinColumn3 = false;
    public static bool twinColumn4 = true;
    public static bool twinColumn5 = false;
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
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .725f, 1))).y;
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

        if (position.x >= xCoordinateColumn1.x && movingLeft && twinColumn2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn1.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn1.x)
            {
                twinColumn1 = true;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = false;
                movingLeft = false;
                movingRight = true;
            }
        }

        if (position.x >= xCoordinateColumn2.x && movingLeft && twinColumn3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn2.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn2.x)
            {
                twinColumn1 = false;
                twinColumn2 = true;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x >= xCoordinateColumn3.x && movingLeft && twinColumn4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn3.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn3.x)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = true;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }
        if (position.x >= xCoordinateColumn4.x && movingLeft && twinColumn5 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn4.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn4.x)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = true;
                twinColumn5 = false;
            }
        }

        if (position.x <= xCoordinateColumn2.x && movingRight && twinColumn1 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn2.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn2.x)
            {
                twinColumn1 = false;
                twinColumn2 = true;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x <= xCoordinateColumn3.x && movingRight && twinColumn2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn3.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn3.x)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = true;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x <= xCoordinateColumn4.x && movingRight && twinColumn3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn4.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn4.x)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = true;
                twinColumn5 = false;
            }
        }

        if (position.x <= xCoordinateColumn5.x && movingRight && twinColumn4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, xCoordinateColumn5.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == xCoordinateColumn5.x)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = true;
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
