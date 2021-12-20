using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    private bool holding = false;
    public GameObject grabpoint;
    public GameObject droppoint;
    public GameObject dropImage;
    private GameObject readygrab;

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

    private void Start()
    {
        dropImage.SetActive(false); //Don't have the drop image be visible
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void Update()
    {
        if (holding)
        {
            readygrab.transform.position = grabpoint.transform.position; //Move the held object with the player.
        }

    }


    public void Grab()
    {
        if (!holding && readygrab != null) //If you're not holding anything and there's something to hold...
        {
            holding = true; //Become holding that thing.
            dropImage.SetActive(true);
        }
        else if (holding) //If you're holding something...
        {
            holding = false; //Stop holding.
            readygrab.transform.position =
                droppoint.transform.position; //Put it down.
            dropImage.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Held") //If it's holdable...
        {
            readygrab = other.gameObject; //Get ready to hold it.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Held") //If it (was) holdable...
        {
            readygrab = null; //Stop being ready to hold things.
        }
    }
}
