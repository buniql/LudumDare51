using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : MonoBehaviour
{
    public float activationDistance;

    private Transform _player;

    private bool _activated;

    private StatHolder _holder;
    private Rigidbody2D _rigidbody2D;
    private Dash _dash;
    private Damage _damage;

    private float _cooldownCounter = -1;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<EntitySpawner>().Player;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _holder = GetComponent<StatHolder>();
        _dash = GetComponent<Dash>();
        _damage = GetComponent<Damage>();
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
            _damage.SetDamage(_holder.Stat.Damage, tag);
            _cooldownCounter = _holder.Stat.ShootCooldown;
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
