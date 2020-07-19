﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRow2 : MonoBehaviour
{
    private const float movementSpeed = 1f;
    public int enemyHealth = 5;

    private Vector2 position;

    //private Direction shipDirection;

    private readonly float speed = 7f;

    private Vector3 startPosition;

    private Vector2 target;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .7f, 1))).y;
    }

    private void Update()
    {
        if (position.y > target.y)
        {
            position.y = Mathf.MoveTowards(transform.position.y, target.y, Time.deltaTime * speed);
            transform.position = position;
        }
    }
}