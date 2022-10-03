using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Stats _stat;
    [SerializeField] SpawnBullet.ProjectileType projectileType;
    [SerializeField] Sprite[] projectileSprites;
    [HideInInspector] public Vector2 direction;
    Rigidbody2D _rb;
    [HideInInspector] public String toAttack;

    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private Sprite _lastSprite;

    void Start()
    {
        _collider = transform.Find("Sprite").GetComponent<CircleCollider2D>();
        _spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();

        SetBulletSprite();
    }

    void SetBulletSprite()
    {
        switch (projectileType) //Set Sprite and resize accordingly
        {
            case SpawnBullet.ProjectileType.Default:
                _spriteRenderer.sprite = projectileSprites[0];
                ResizeCollider(0);
                break;
            case SpawnBullet.ProjectileType.Fire:
                _spriteRenderer.sprite = projectileSprites[1];
                ResizeCollider(1);
                break;
            case SpawnBullet.ProjectileType.Bounce:
                _spriteRenderer.sprite = projectileSprites[2];
                ResizeCollider(2);
                break;
            case SpawnBullet.ProjectileType.Blob:
                _spriteRenderer.sprite = projectileSprites[3];
                ResizeCollider(3);
                break;
            case SpawnBullet.ProjectileType.Big:
                _spriteRenderer.sprite = projectileSprites[4];
                ResizeCollider(4);
                break;
            case SpawnBullet.ProjectileType.AutoAim:
                _spriteRenderer.sprite = projectileSprites[5];
                ResizeCollider(5);
                break;
        }
    }

    private void ResizeCollider(int projectileIndex)
    {
        if (_spriteRenderer.sprite != _lastSprite)
        {
            Vector3 spriteHalfSize = _spriteRenderer.sprite.bounds.extents;
            _collider.radius = spriteHalfSize.x > spriteHalfSize.y ? spriteHalfSize.x : spriteHalfSize.y;
            _lastSprite = _spriteRenderer.sprite;
        }
    }

    void FixedUpdate() //alter flight parth of projectile
    {
        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        _rb.MovePosition(_rb.position + direction * _stat.Speed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        Debug.Log(toAttack);
        if (collider.gameObject.tag == toAttack) //What happens when projectile hits
            Destroy(gameObject);
    }

    public void ConfigureBullet(Vector2 direction, String tag)
    {
        this.direction = direction;
        // SetBulletSprite();

        if (tag == "Player")
            toAttack = "Enemy";
        else if (tag == "Enemy")
            toAttack = "Player";
        else
            Debug.Log("No correct Tag, something went wrong");
    }
}