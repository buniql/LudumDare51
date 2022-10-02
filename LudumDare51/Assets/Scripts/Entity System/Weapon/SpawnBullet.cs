using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;
    private float _cooldownCounter;

    Camera _mainCamera;
    Transform _playerTransform;

    void Awake()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _holder = GetComponentInParent<StatHolder>();
        _cooldownCounter = _holder.Stat.ShootCooldown;
        _mainCamera = Camera.main;
    }

    void Update()
    {
        var direction = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (direction.x < _playerTransform.position.x)
            _playerTransform.rotation = Quaternion.Euler(0, 180, 0);

        if (direction.x > _playerTransform.position.x)
            _playerTransform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetMouseButton(0) && _cooldownCounter < 0)
        {
            _cooldownCounter = _holder.Stat.ShootCooldown;
            var weapon = _holder.Stat.Weapon;

            var damage = weapon.GetComponent<Damage>();
            damage.SetDamage(_holder.Stat.Damage, _playerTransform.gameObject.tag);

            var bullet = weapon.GetComponent<Bullet>();
            bullet.ConfigureBullet(direction - transform.position, _playerTransform.gameObject.tag);

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }

        _cooldownCounter -= Time.deltaTime;
    }
}
