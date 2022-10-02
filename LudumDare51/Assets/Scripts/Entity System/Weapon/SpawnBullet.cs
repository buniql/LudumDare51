using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;

    private float _cooldownCounter;

    void Awake()
    {
        _holder = GetComponentInParent<StatHolder>();
        _cooldownCounter = _holder.Stat.ShootCooldown;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _cooldownCounter < 0)
        {
            _cooldownCounter = _holder.Stat.ShootCooldown;
            var weapon = _holder.Stat.Weapon;
            var bullet = weapon.GetComponent<Bullet>();
            bullet.ConfigureBullet(_holder.Stat.Damage, new Vector2(1, 0));

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }

        _cooldownCounter -= Time.deltaTime;
    }
}
