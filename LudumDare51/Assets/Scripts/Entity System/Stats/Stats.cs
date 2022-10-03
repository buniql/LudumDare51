using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Object", menuName = "Objects/Stats")]
public class Stats : ScriptableObject
{
    [SerializeField] GameObject _weapon;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _shootCooldown;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    [Space]

    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashLength;
    [SerializeField] private float _dashCooldown;

    private Action _deathEvent;
    private int health;

    public GameObject Weapon { get { return _weapon; } }
    public int Damage { get { return _damage; } }
    public float Speed { get { return _speed; } }
    public float DashSpeed { get { return _dashSpeed; } }
    public float DashLength { get { return _dashLength; } }
    public float DashCooldown { get { return _dashCooldown; } }
    public float ShootCooldown { get { return _shootCooldown; } }
    public int MaxHealth { get { return _maxHealth; } }

    public int Health
    {
        get { return health; }
        set
        {
            if (value > _maxHealth)
                health = _maxHealth;
            else if (value <= 0)
            {
                health = 0;

                if (_deathEvent != null)
                    _deathEvent.Invoke();
                else
                    Debug.Log("Death Event is null");
            }
            else
                health = value;
        }
    }

    public void Start()
    {
        health = _maxHealth;
    }

    public void SetDeathEvent(Action action)
        => _deathEvent = action;

    public void GetDamage(int damage)
        => Health -= damage;

    public static Stats operator +(Stats lhs, Stats rhs)
    {
        Stats toReturn = ScriptableObject.CreateInstance<Stats>();

        toReturn._maxHealth += lhs._maxHealth + rhs._maxHealth;
        toReturn._damage += lhs._damage + rhs._damage;
        toReturn._speed += lhs._speed + rhs._speed;
        toReturn._dashSpeed += lhs._dashSpeed + rhs._dashSpeed;
        toReturn._dashLength += lhs._dashLength + rhs._dashLength;
        toReturn._dashCooldown += lhs._dashCooldown + rhs._dashCooldown;
        toReturn._shootCooldown += lhs._shootCooldown + rhs._shootCooldown;
        Mathf.Clamp(toReturn._shootCooldown, .2f, 10f);
        toReturn.Health = lhs.Health;

        if (rhs.Weapon != null)
            toReturn._weapon = rhs._weapon;
        else
            toReturn._weapon = lhs._weapon;

        return toReturn;
    }
}

