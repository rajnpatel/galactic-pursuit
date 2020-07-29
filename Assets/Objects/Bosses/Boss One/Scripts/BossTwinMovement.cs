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


    void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .725f, 1))).y;

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

        if (position.x >= -3 && movingLeft && twinColumn2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -3, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -3)
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

        if (position.x >= -1.5 && movingLeft && twinColumn3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -1.5)
            {
                twinColumn1 = false;
                twinColumn2 = true;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x >= 0 && movingLeft && twinColumn4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 0)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = true;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }
        if (position.x >= 1.5 && movingLeft && twinColumn5 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 1.5)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = true;
                twinColumn5 = false;
            }
        }

        if (position.x <= -1.5 && movingRight && twinColumn1 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, -1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == -1.5)
            {
                twinColumn1 = false;
                twinColumn2 = true;
                twinColumn3 = false;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x <= 0 && movingRight && twinColumn2 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 0)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = true;
                twinColumn4 = false;
                twinColumn5 = false;
            }
        }

        if (position.x <= 1.5 && movingRight && twinColumn3 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 1.5f, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 1.5)
            {
                twinColumn1 = false;
                twinColumn2 = false;
                twinColumn3 = false;
                twinColumn4 = true;
                twinColumn5 = false;
            }
        }

        if (position.x <= 3 && movingRight && twinColumn4 && settingPosition == false)
        {
            position.x = Mathf.MoveTowards(transform.position.x, 3, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == 3)
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
