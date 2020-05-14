using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPosition : MonoBehaviour
{
    public GameObject settings;
    void Start()
    {
        transform.position = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 1));
    }
}
