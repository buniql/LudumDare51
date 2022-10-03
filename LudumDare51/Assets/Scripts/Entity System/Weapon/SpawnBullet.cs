using System.Collections;

using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    StatHolder _holder;
    public static ProjectileType projectileType;
    public ProjectileType type;
    private float _cooldownCounter;
    private Animator _playerAnimator;

    Camera _mainCamera;
    Transform _playerTransform;

    public enum ProjectileType
    {
        Default, //default spell
        Fire, //explosive fireball
        Bounce, //bounces off enemys
        AutoAim, //targets closes enemy
        Big, //giant projectile
        Blob //stays at mouseposition
    }

    void Awake()
    {
        _playerAnimator = GameObject.Find("PlayerSprite").GetComponent<Animator>();
        projectileType = type;
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _holder = GetComponentInParent<StatHolder>();
        _cooldownCounter = _holder.Stat.ShootCooldown;
        _mainCamera = Camera.main;
    }

    void Update()
    {
        var direction = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (direction.x < _playerTransform.position.x)
            _playerTransform.rotation = Quaternion.Euler(0, 180, 0);

        if (direction.x > _playerTransform.position.x)
            _playerTransform.rotation = Quaternion.Euler(0, 0, 0);

        if (Input.GetMouseButton(0) && _cooldownCounter < 0)
        {
            _playerAnimator.SetBool("Attack", true);

            _cooldownCounter = _holder.Stat.ShootCooldown;
            var weapon = _holder.Stat.Weapon;
            Debug.Log(weapon.gameObject.name);

            var damage = weapon.GetComponent<Damage>();
            damage.SetDamage(_holder.Stat.Damage, _playerTransform.gameObject.tag);

            var bullet = weapon.GetComponent<Bullet>(); //change spawn amount?
            bullet.ConfigureBullet(direction - transform.position, _playerTransform.gameObject.tag);

            GameObject.Instantiate(weapon, gameObject.transform.position, Quaternion.identity);
        }

        if(!Input.GetMouseButton(0) || _cooldownCounter < _holder.Stat.ShootCooldown/2) _playerAnimator.SetBool("Attack", false);

        _cooldownCounter -= Time.deltaTime;
    }
}
