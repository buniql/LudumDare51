using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTickController : MonoBehaviour
{
    [SerializeField] int damageTime;
    [SerializeField] int damage;

    [SerializeField] UIController ui;

    StatHolder player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<StatHolder>();
        StartCoroutine(Damage());
    }

    IEnumerator Damage()
    {
        while (true)
        {
            for (int i = damageTime; i >= 0; i--)
            {
                ui.SetTimedDamage(i);
                yield return new WaitForSeconds(1);
            }

            player.Stat.GetDamage(damage);
        }
    }
}
