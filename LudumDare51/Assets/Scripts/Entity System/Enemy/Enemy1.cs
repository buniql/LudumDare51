using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;
    public float activationDistance;
    public GameObject[] spawner;

    private Transform _player;

    private bool _activated;

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
        _activated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = _player.transform.position - transform.position;
        if (direction.sqrMagnitude > 1f) direction.Normalize();
        float rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

        if ((_player.transform.position - transform.position).sqrMagnitude > activationDistance && !_activated)
            Idle();
        else
            if(!_activated) _activated = true;

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
            Debug.Log("Cooldown: " + _holder.Stat.ShootCooldown);
            _cooldownCounter = _holder.Stat.ShootCooldown;
            var weapon = _holder.Stat.Weapon;

            var damage = weapon.GetComponent<Damage>();
            damage.SetDamage(_holder.Stat.Damage, tag);

            for(int i = 0; i < spawner.Length; i++)
            {
                var bullet = weapon.GetComponent<Bullet>();
                bullet.ConfigureBullet((spawner[i].transform.position - transform.position), tag);

                Instantiate(weapon, spawner[i].transform.position, Quaternion.identity);
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
