using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRow3 : MonoBehaviour
{
    private Vector2 position;
    private readonly float speed = 7f;
    private Vector2 target;

    private void Start()
    {
        position = transform.position;
        target.y = (Camera.main.ViewportToWorldPoint(new Vector3(0f, .775f, 1))).y;
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