using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatHolder : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [SerializeField] Image deadPanel;

    public Stats Stat { get { return _stat; } }

    void Awake()
    {
        _stat = Instantiate(_stat);
        
        if(gameObject.name == "Player")
            Stat.IchBinSoSad(deadPanel);

        Stat.Start();
    }

    public void AddStat(Stats toAdd)
    {
        _stat += toAdd;
    }
}