using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] UIController ui;

    [Space(10)]

    [SerializeField] List<Skills> skills;
    bool shopIsOpen;

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

        return randomSkills;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !shopIsOpen)
        {
            ui.OpenShop(GetRandomSkills());
            shopIsOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && shopIsOpen)
        {
            ui.CloseShop();
            shopIsOpen = false;
        }
    }
}
