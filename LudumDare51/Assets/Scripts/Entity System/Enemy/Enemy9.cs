using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy9 : MonoBehaviour
{
    public int gunRounds;
    public float gunSpray;
    public float activationDistance;
    public GameObject spawner;

    private Transform _player;

    private bool _activated;
    private int _maxHealth;

    private StatHolder _holder;
    private Rigidbody2D _rigidbody2D;
    private Dash _dash;

    private float _cooldownCounter = -1;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<EntitySpawner>().Player;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _holder = GetComponent<StatHolder>();
        _dash = GetComponent<Dash>();
        _maxHealth = _holder.Stat.Health;
        _activated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = _player.transform.position - transform.position;
        if (direction.sqrMagnitude > 1f) direction.Normalize();

        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);

        if (direction.x < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);

        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.Find("Rotater").transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        if (_holder.Stat.Health != _maxHealth) _activated = true;

        if ((_player.transform.position - transform.position).sqrMagnitude > activationDistance && !_activated)
            Idle();
        else
            if (!_activated) _activated = true;

        if (_activated)
        {
            _rigidbody2D.MovePosition(transform.position + direction * _holder.Stat.Speed);

            Attack();
        }
    }


    void Idle()
    {

    }

    void Attack()
    {
        if (_cooldownCounter < 0)
        {
            Vector2[] shots = new Vector2[gunRounds];

            Debug.Log("Cooldown: " + _holder.Stat.ShootCooldown);
            _cooldownCounter = _holder.Stat.ShootCooldown;
            var weapon = _holder.Stat.Weapon;

            var damage = weapon.GetComponent<Damage>();
            damage.SetDamage(_holder.Stat.Damage, tag);

            for (int i = 0; i < gunRounds; i++)
            {
                var bullet = weapon.GetComponent<Bullet>();
                bullet.ConfigureBullet(((spawner.transform.position - transform.position) + new Vector3(Random.Range(-gunSpray, gunSpray), Random.Range(-gunSpray, gunSpray), 0)), tag);

                Instantiate(weapon, spawner.transform.position, Quaternion.identity);
            }
        }
        _cooldownCounter -= Time.deltaTime;
    }

    void Pause()
    {
        throw new System.NotImplementedException();
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
