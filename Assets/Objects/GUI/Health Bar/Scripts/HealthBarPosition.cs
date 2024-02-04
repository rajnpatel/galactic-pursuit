using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPosition : MonoBehaviour
{
    public GameObject healthBar;
    private void Awake()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(-Screen.width + Screen.width, Screen.height - 50, 1));
        Instantiate(healthBar, transform.position, transform.rotation);
    }
}
