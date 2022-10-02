using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [HideInInspector] public int damage;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var dir = new Vector2(1, 0);

        if (dir.sqrMagnitude > 1f)
            dir.Normalize();

        _rb.MovePosition(_rb.position + dir * _stat.Speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var holder = collider.gameObject.GetComponent<StatHolder>();
        holder.Stat.GetDamage(damage);

        Destroy(gameObject);
    }
}
