using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeath : MonoBehaviour
{
    void Start()
    {
        var holder = gameObject.GetComponent<StatHolder>();
        holder.Stat.SetDeathEvent(Death);
    }

    public virtual void Death()
    {
        // Play Animation
        Debug.Log("Killed " + gameObject.name);
        Destroy(gameObject);
    }
}