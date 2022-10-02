using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
        {
            collider2D.gameObject.GetComponent<StatHolder>().Stat.GetDamage(-10);
            Destroy(gameObject);
        }
    }
}
