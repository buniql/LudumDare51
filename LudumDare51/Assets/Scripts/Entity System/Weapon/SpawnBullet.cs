using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;

    private float _cooldown = .3f;
    private float _cooldownCounter;

    void Awake()
    {
        _holder = GetComponentInParent<StatHolder>();
        _cooldownCounter = _cooldown;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _cooldownCounter < 0)
        {
            _cooldownCounter = _cooldown;
            var weapon = _holder.Stat.Weapon;
            var bullet = weapon.GetComponent<Bullet>();
            bullet.damage = _holder.Stat.Damage;

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }

        _cooldownCounter -= Time.deltaTime;
    }
}
