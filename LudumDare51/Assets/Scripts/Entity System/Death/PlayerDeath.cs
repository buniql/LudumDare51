using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : BaseDeath
{

    public GameObject bullet;

    public override void Death()
    {
        Instantiate(bullet);

        // Specifics for Player Death, like, restart scene or show Death UI
        Debug.Log("Player died, show UI e.g.");
        base.Death();
    }
}