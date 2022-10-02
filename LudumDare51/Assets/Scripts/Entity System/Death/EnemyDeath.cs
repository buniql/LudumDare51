using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : BaseDeath
{
    [SerializeField] GameObject live;

    public override void Death()
    {
        Instantiate(live, transform.position, Quaternion.identity);
        base.Death();
    }
}
