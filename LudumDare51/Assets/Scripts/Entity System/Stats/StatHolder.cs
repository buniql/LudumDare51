using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class StatHolder : MonoBehaviour
{
    [SerializeField] Stats _stat;
    public Stats Stat { get { return _stat; } }

    void Awake()
    {
        _stat = Instantiate(_stat);
        Stat.Start();
    }

    public void AddStat(Stats toAdd)
    {
        _stat += toAdd;
    }
}