using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeath : MonoBehaviour
{
    public virtual void Death()
    {
        // Play Animation
        Debug.Log("BaseDeath");
        Destroy(gameObject);
    }
}