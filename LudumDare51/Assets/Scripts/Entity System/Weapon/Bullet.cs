using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [HideInInspector] public Vector2 direction;
    Rigidbody2D _rb;

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

    void OnTriggerEnter2D(Collider2D collider) =>
        Destroy(gameObject);

    public void ConfigureBullet(Vector2 direction)
    {
        this.direction = direction;
    }
}