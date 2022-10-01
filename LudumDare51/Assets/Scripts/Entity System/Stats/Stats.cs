using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Object", menuName = "Objects/Stats")]
public class Stats : ScriptableObject
{
    [SerializeField] private int maxHealth;

    public int damage;
    public float speed;
    public float dashSpeed;
    public float dashLength;
    public float dashCooldown;
    private Action _deathEvent;

    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            if (value > maxHealth)
                health = maxHealth;
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

    void Awake() => Health = maxHealth;

    public void SetDeathEvent(Action action) => _deathEvent = action;

    public void GetDamage(Stats enemy)
        => health -= enemy.damage;

    public static Stats operator +(Stats lhs, Stats rhs)
    {
        Stats toReturn = ScriptableObject.CreateInstance<Stats>();

        toReturn.maxHealth += lhs.maxHealth + rhs.maxHealth;
        toReturn.damage += lhs.damage + rhs.damage;
        toReturn.speed += lhs.speed + rhs.speed;
        toReturn.dashSpeed += lhs.dashSpeed + rhs.dashSpeed;
        toReturn.dashLength += lhs.dashLength + rhs.dashLength;
        toReturn.dashCooldown += lhs.dashCooldown + rhs.dashCooldown;

        return toReturn;
    }
}

