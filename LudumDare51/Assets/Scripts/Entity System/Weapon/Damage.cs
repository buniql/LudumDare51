using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [HideInInspector] public int _damage;

    [HideInInspector] public String toAttack;

    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SetDamage(int damage, string tag)
    {
        _damage = damage;

        if (tag == "Player")
            toAttack = "Enemy";
        else if (tag == "Enemy")
            toAttack = "Player";
        else
            Debug.Log("No correct Tag, something went wrong");
    }

    void Attack(Collider2D collider)
    {
        if (collider.gameObject.tag == toAttack)
        {
            // _audio.Play();
            var holder = collider.gameObject.GetComponent<StatHolder>();
            holder.Stat.GetDamage(_damage);
            _damage = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) => Attack(collider);
    void OnTriggerStay2D(Collider2D collider) => Attack(collider);
}
