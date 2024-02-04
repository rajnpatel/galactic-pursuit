using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPosition : MonoBehaviour
{
    public GameObject settings;
    void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 50, Screen.height - 50, 1));
    }
}