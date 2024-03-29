﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3EnemyMovementRow2 : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private float rotationSpeed = 6f;
    private Vector2 target;
    private Vector2 bottomLeftCorner;
    private Vector2 topLeftCorner;
    private Vector2 topRightCorner;
    private Vector2 bottomRightCorner;
    private Vector2 newTarget;
    private Vector2 initialX;
    public bool settingPosition = true;
    public static bool initialOffScreenMove = true;
    public static bool secondOffScreenMove = false;
    private bool returningToScreen = false;
    public bool canStartCoroutine = true;
    public bool relocatedTrigger = false;
    private Vector2 newTopCorner;
    public static bool delayRelocatedTrigger = false;
    private void Start()
    {
        position = transform.position;
        initialX.x = transform.position.x;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .7f, 1))).y;
        bottomLeftCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.3f, 0f, 1))).x;
        topLeftCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.775f, 1))).y;
        topRightCorner.x = (Camera.main.ViewportToWorldPoint(new Vector3(0.7f, 0f, 1))).x;
        bottomRightCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0, .7f, 1))).y;

        newTarget.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .375f, 1))).y;
        newTarget.x = (Camera.main.ViewportToWorldPoint(new Vector3(-0.5f, 0, 1))).x;
        newTopCorner.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .45f, 1))).y;

        initialOffScreenMove = true;
        secondOffScreenMove = false;
        returningToScreen = false;
    }

    private void Update()
    {
        if (position.y > target.y && settingPosition)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
            if (position.y == target.y && settingPosition)
            {
                settingPosition = false;
            }
        }
        if (EnemyShield.triggered)
        {
            if (position.x <= topRightCorner.x && position.y == bottomRightCorner.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == topRightCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, topLeftCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.y == topLeftCorner.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == bottomLeftCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, bottomRightCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
        }
        if (EnemyShield.relocating && initialOffScreenMove)
        {
            position.x = Mathf.MoveTowards(transform.position.x, newTarget.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == newTarget.x)
            {
                initialOffScreenMove = false;
                StartCoroutine(switchOffScreenMovement());
            }
        }
        if (EnemyShield.relocating && secondOffScreenMove)
        {
            position.y = Mathf.MoveTowards(transform.position.y, newTarget.y, Time.deltaTime * speed);
            transform.position = position;
            if (position.y == newTarget.y && canStartCoroutine)
            {
                canStartCoroutine = false;
                StartCoroutine(switchOffScreenMovement2());
            }
        }
        if (EnemyShield.relocating && returningToScreen)
        {
            position.x = Mathf.MoveTowards(transform.position.x, initialX.x, Time.deltaTime * speed);
            transform.position = position;
            if (position.x == initialX.x)
            {
                returningToScreen = false;
                delayRelocatedTrigger = true;
            }
        }
        if (delayRelocatedTrigger)
        {
            delayRelocatedTrigger = false;
            StartCoroutine(enableRelocatedTrigger());
        }
        if (relocatedTrigger && !EnemyShield.shield)
        {
            if (position.x <= topRightCorner.x && position.y == newTarget.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, topRightCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == topRightCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, newTopCorner.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.y == newTopCorner.y)
            {
                position.x = Mathf.MoveTowards(transform.position.x, bottomLeftCorner.x, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
            if (position.x == bottomLeftCorner.x)
            {
                position.y = Mathf.MoveTowards(transform.position.y, newTarget.y, Time.deltaTime * rotationSpeed);
                transform.position = position;
            }
        }
    }
    public IEnumerator switchOffScreenMovement()
    {
        yield return new WaitForSeconds(0.5f);
        secondOffScreenMove = true;
    }
    public IEnumerator switchOffScreenMovement2()
    {
        yield return new WaitForSeconds(0.5f);
        secondOffScreenMove = false;
        returningToScreen = true;
    }
    public IEnumerator enableRelocatedTrigger()
    {
        yield return new WaitForSeconds(1f);
        relocatedTrigger = true;
    }
}