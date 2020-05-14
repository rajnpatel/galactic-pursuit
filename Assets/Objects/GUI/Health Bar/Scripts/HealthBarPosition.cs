using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPosition : MonoBehaviour
{
    public GameObject healthBar;
    private void Awake()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, 1));
        Instantiate(healthBar, transform.position, transform.rotation);
    }
}
