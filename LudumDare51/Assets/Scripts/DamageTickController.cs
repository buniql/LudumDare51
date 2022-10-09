using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTickController : MonoBehaviour
{
    [SerializeField] int damageTime;
    [SerializeField] int damage;

    [SerializeField] UIController ui;
    AudioSource _audio;

    StatHolder player;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
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

            _audio.Play();
            player.Stat.GetDamage(damage);
        }
    }
}
