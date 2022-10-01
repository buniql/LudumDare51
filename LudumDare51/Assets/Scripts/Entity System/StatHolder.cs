using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class StatHolder : MonoBehaviour
{
    [SerializeField] Stats _stat;
    public Stats Stat { get { return _stat; } }

    [SerializeField] Stats testSecondStat;

    public void AddStat(Stats toAdd)
    {
        _stat += toAdd;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            AddStat(testSecondStat);
    }
}
