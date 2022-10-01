using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;

    void Awake()
    {
        _holder = GetComponent<StatHolder>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }
}
