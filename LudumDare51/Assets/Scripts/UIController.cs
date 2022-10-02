using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    StatHolder playerStats;
    [SerializeField] TextMeshProUGUI hp;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<StatHolder>();
    }

    void Update()
    {
        hp.SetText($"HP: {playerStats.Stat.Health}/{playerStats.Stat.MaxHealth}");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
