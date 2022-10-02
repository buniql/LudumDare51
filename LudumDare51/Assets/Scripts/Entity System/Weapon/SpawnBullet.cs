using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;

    void Awake()
    {
        _holder = GetComponentInParent<StatHolder>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var weapon = _holder.Stat.Weapon;
            var bullet = weapon.GetComponent<Bullet>();
            bullet.damage = _holder.Stat.Damage;

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }
    }
}
