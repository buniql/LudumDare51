using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    StatHolder playerStats;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI timedDamage;
    [SerializeField] TextMeshProUGUI shopText;

    [Space(10)]
    [SerializeField] Image shopPanel;
    [SerializeField] TextMeshProUGUI[] shopSlots;
    [SerializeField] Button[] buttons;

    string shopIsOpenText = "<color=green>Shop is open!</color>";

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<StatHolder>();
        shopText.text = shopIsOpenText;
    }

    void Update()
    {
        hp.SetText($"HP: <color=red>{playerStats.Stat.Health}/{playerStats.Stat.MaxHealth}</color>");
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

                if (buttons[1] != null)
                    buttons[1].gameObject.SetActive(true);

                return;
            }
            else if (i == 1 && skills[2] == null)
            {
                shopSlots[2].text = skills[i].ToString();

                if (buttons[2] != null)
                    buttons[2].gameObject.SetActive(true);

                return;
            }

            shopSlots[i].text = skills[i].ToString();

            if (buttons[i] != null)
            {
                buttons[i].gameObject.SetActive(true);
            }
            else
                Debug.Log("Eine Tragik");
        }
    }

    public void SetTimedDamage(int secondsLeft) =>
        timedDamage.text = $"Next Damage in: {secondsLeft}";

    public void ShopOpen(int secondsLeft)
    {
        if (secondsLeft == 0)
            shopText.text = shopIsOpenText;
        else
            shopText.text = $"Shop opens in: {secondsLeft}";
    }

    public void CloseShop()
    {
        Time.timeScale = 1;

        foreach (var button in buttons)
            if (button != null)
                button.gameObject.SetActive(false);

        shopPanel.gameObject.SetActive(false);
    }
}
