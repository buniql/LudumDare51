using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : MonoBehaviour
{
    public GameObject summonedEnemy;

    public float activationDistance;

    private Transform _player;

    private bool _activated;
    private int _maxHealth;
    private bool _firstInstance;
    private bool _secondInstance;

    private StatHolder _holder;
    private Rigidbody2D _rigidbody2D;
    private Dash _dash;
    private Damage _damage;

    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<EntitySpawner>().Player;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _holder = GetComponent<StatHolder>();
        _dash = GetComponent<Dash>();
        _damage = GetComponent<Damage>();
        _activated = false;
        _maxHealth = _holder.Stat.Health;
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

            Summon();
        }
    }

    void Idle()
    {
        
    }

    void Summon()
    {
        Vector2 summonPosition = 2 * (_player.transform.position - transform.position).normalized;
        if(_holder.Stat.Health <= _maxHealth / 2 && !_firstInstance)
        {
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position + summonPosition * Vector3.left, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position + summonPosition * -Vector3.left, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            _firstInstance = true;
        }
        if (_holder.Stat.Health <= _maxHealth / 4 && !_secondInstance)
        {
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position + summonPosition, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position - summonPosition, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position + summonPosition * Vector3.left, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            GameObject.Instantiate(summonedEnemy, (Vector2)transform.position + summonPosition * -Vector3.left, Quaternion.identity, GameObject.Find("Entity Spawner").transform);
            _secondInstance = true;
        }
    }

    void Death()
    {
        Destroy(this.gameObject);
    }
}
