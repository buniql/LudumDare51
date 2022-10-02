using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [HideInInspector] public int _damage;

    public void SetDamage(int damage) =>
        _damage = damage;

    void OnTriggerEnter2D(Collider2D collider)
    {
        var holder = collider.gameObject.GetComponent<StatHolder>();
        holder.Stat.GetDamage(_damage);
    }
}
