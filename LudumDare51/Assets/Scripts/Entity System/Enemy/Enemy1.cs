using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float movementSpeed;
    public float activationDistance;

    private Transform _player;

    private bool _activated;
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.parent.GetComponent<EntitySpawner>().Player;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _activated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.parent.GetComponent<EntitySpawner>().Player.position - transform.position).sqrMagnitude > activationDistance && !_activated)
            Idle();
        else
            if(!_activated) _activated = true;

        if (_activated)
        {
            Vector3 direction = (_player.transform.position - transform.position);

            if (direction.sqrMagnitude > 1f) direction.Normalize();

            _rigidbody2D.MovePosition(transform.position + direction * movementSpeed);
        }
    }


    void Idle()
    {
        
    }

    void Attack()
    {
        throw new System.NotImplementedException();
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
