using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{

    PlayerControler playercontrols;
    private void OnEnable()
    {
        if (playercontrols == null)
        {
            playercontrols = new PlayerControler();
            playercontrols.Action.Grab.performed += i => Grab();
        }

        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void Awake()
    {
       
    }

    public void Grab()
    {
        Debug.Log("GRAB");
    }
}
