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
            bullet.ConfigureBullet(_holder.Stat.Damage, new Vector2(1, 0));

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }
    }
}
