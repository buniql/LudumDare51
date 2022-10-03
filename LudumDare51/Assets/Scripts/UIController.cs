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

    [Space(10)]
    [SerializeField] Image shopPanel;
    [SerializeField] TextMeshProUGUI[] shopSlots;


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

    public void OpenShop(Skills[] skills)
    {
        Time.timeScale = 0;
        shopPanel.gameObject.SetActive(true);

        for (int i = 0; i < skills.Length; i++)
        {
            if (i == 0 && skills[1] == null)
            {
                shopSlots[1].text = skills[i].ToString();
                shopSlots[1].gameObject.SetActive(true);

                return;
            }
            else if (i == 1 && skills[2] == null)
            {
                shopSlots[2].text = skills[i].ToString();
                shopSlots[2].gameObject.SetActive(true);

                return;
            }

            shopSlots[i].text = skills[i].ToString();
            shopSlots[i].gameObject.SetActive(true);
        }
    }

    public void CloseShop()
    {
        Time.timeScale = 1;

        foreach (var slot in shopSlots)
            slot.gameObject.SetActive(false);

        shopPanel.gameObject.SetActive(false);
    }
}
