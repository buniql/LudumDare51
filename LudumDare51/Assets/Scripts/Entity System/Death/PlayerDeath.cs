using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class PlayerDeath : BaseDeath
{

    public GameObject bullet;
    public UnityEngine.UI.Image deadPanel;

    public override void Death()
    {
        Time.timeScale = 0;
        deadPanel.gameObject.SetActive(true);

        // Specifics for Player Death, like, restart scene or show Death UI
        Debug.Log("Player died, show UI e.g.");
        base.Death();
    }
}