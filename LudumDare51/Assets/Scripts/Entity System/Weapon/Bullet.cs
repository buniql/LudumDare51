using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [HideInInspector] public int damage;
    [HideInInspector] public Vector2 direction;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - GameObject.Find("Player").transform.position;
    }

    void FixedUpdate()
    {
        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        _rb.MovePosition(_rb.position + direction * _stat.Speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var holder = collider.gameObject.GetComponent<StatHolder>();
        holder.Stat.GetDamage(damage);

        Destroy(gameObject);
    }

    public void ConfigureBullet(int damage, Vector2 direction)
    {
        this.damage = damage;
        this.direction = direction;
    }
}