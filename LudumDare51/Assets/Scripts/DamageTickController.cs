using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTickController : MonoBehaviour
{
    [SerializeField] int damageTime;
    [SerializeField] int damage;

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
            yield return new WaitForSeconds(damageTime);
            player.Stat.GetDamage(damage);
        }
    }
}
