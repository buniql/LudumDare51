using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats Object", menuName = "Objects/Stats")]
public class Stats : ScriptableObject
{
    public int damage;
    public float speed;
    public float dashSpeed;
    public float dashLength;
    public float dashCooldown;

    public static Stats operator +(Stats lhs, Stats rhs)
    {
        Stats toReturn = ScriptableObject.CreateInstance<Stats>();

        toReturn.damage += lhs.damage + rhs.damage;
        toReturn.speed += lhs.speed + rhs.speed;
        toReturn.dashSpeed += lhs.dashSpeed + rhs.dashSpeed;
        toReturn.dashLength += lhs.dashLength + rhs.dashLength;
        toReturn.dashCooldown += lhs.dashCooldown + rhs.dashCooldown;

        return toReturn;
    }
}

