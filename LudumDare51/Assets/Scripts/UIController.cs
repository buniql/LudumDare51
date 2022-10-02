using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    StatHolder playerStats;
    [SerializeField] TextMeshProUGUI hp;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<StatHolder>();
    }

    void Update()
    {
        hp.SetText($"HP: {playerStats.Stat.Health}/{playerStats.Stat.MaxHealth}");
    }
}
