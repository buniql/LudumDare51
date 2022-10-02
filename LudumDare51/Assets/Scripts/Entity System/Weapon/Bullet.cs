using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [HideInInspector] public Vector2 direction;
    Rigidbody2D _rb;
    [HideInInspector] public String toAttack;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        _rb.MovePosition(_rb.position + direction * _stat.Speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        Debug.Log(toAttack);
        if (collider.gameObject.tag == toAttack)
            Destroy(gameObject);
    }

    public void ConfigureBullet(Vector2 direction, String tag)
    {
        this.direction = direction;

        if (tag == "Player")
            toAttack = "Enemy";
        else if (tag == "Enemy")
            toAttack = "Player";
        else
            Debug.Log("No correct Tag, something went wrong");
    }
}