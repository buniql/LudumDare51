using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] UIController ui;

    [Space(10)]

    [SerializeField] List<Skills> skills;
    [SerializeField] int _shopCooldown;

    bool shopIsOpen;
    bool shopCanBeOpened = true;

    StatHolder _holder;
    Skills[] randomSkillsCache;

    void Start()
    {
        _holder = GameObject.Find("Player").GetComponent<StatHolder>();
    }

    Skills[] GetRandomSkills()
    {
        var randomSkills = new Skills[3];

        int index = 0;

        for (int i = 0; i <= (skills.Count <= 2 ? skills.Count : randomSkills.Length - 1); i++)
        {
            var random = new System.Random();
            index += random.Next(0, skills.Count);

            if (index >= skills.Count)
                index -= skills.Count;

            randomSkills[i] = skills[index];
            skills.RemoveAt(index);
        }

        randomSkillsCache = randomSkills;

        return randomSkills;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !shopIsOpen && shopCanBeOpened)
        {
            ui.OpenShop(GetRandomSkills());
            shopIsOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && shopIsOpen)
        {
            ui.CloseShop();
            shopIsOpen = false;

            StartCoroutine(ShopCooldown());
        }
    }

    public void AddSkill(int slot)
    {
        Debug.Log("It costs: " + randomSkillsCache[slot].Costs + " Lives");
        _holder.AddStat(randomSkillsCache[slot].Stat);
        _holder.Stat.GetDamage(20);

        ui.CloseShop();
        shopIsOpen = false;

        StartCoroutine(ShopCooldown());
    }

    IEnumerator ShopCooldown()
    {
        shopCanBeOpened = false;
        yield return new WaitForSeconds(_shopCooldown);
        shopCanBeOpened = true;
    }
}
