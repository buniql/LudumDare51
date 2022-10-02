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

        Debug.Log(_playerTransform.gameObject.name);
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
            var bullet = weapon.GetComponent<Bullet>();
            bullet.ConfigureBullet(_holder.Stat.Damage, direction - transform.position);

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }

        _cooldownCounter -= Time.deltaTime;
    }
}
