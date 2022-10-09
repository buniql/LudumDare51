using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : BaseDeath
{
    [SerializeField] GameObject live;

    public override void Death()
    {
        var vec = transform.position;
        Instantiate(live, new Vector3(vec.x, vec.y, 389), Quaternion.identity);
        base.Death();
    }
}
