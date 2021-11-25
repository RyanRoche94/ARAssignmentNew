using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElectroScript : MonoBehaviour
{
    public Material onmaterial;
    public Material offmaterial;
    public GameObject chargeparticle;
    
    public bool isSource;

    public bool charged = false;

    public bool discharged = false;

    public float timer = 0;
    public float othertimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MeshRenderer renderer = GetComponent <MeshRenderer>();
        Material material = renderer.material;

        if (discharged) //If you're discharged...
        {
            Debug.Log("Discharged If");
            timer += Time.deltaTime; //Start a timer.
            if (timer >= 3) //After 3 seconds...
            {
                Debug.Log("TimerUp");
                discharged = false; //Stop being discharged.
                timer = 0; //And reset the timer.
            }
        }

        if (charged == true)
        {
            Debug.Log("Charged");
            GetComponent<MeshRenderer>().material = onmaterial; //Change material.
            chargeparticle.SetActive(true); //Activate a particle system.
            othertimer += Time.deltaTime; //Start incrementing a timer.
            

            if (!isSource && othertimer > 2) //If the timer is up...
            {
                charged = false; //Become not charged.
                discharged = true; //Become discharged.
                othertimer = 0; //Reset the timer.
                //Debug.Log("AAAAAAAAAAAAAAAAAAA"); //Freak out for attention.
            }
        }
        else if (!charged)
        {
            GetComponent<MeshRenderer>().material = offmaterial; //Change material.
            chargeparticle.SetActive(false); //Deactivate a particle system.
            Debug.Log("Uncharged");
        }
        
        Debug.Log(discharged);

        //if (Input.GetKeyDown(KeyCode.F))
        //{
            pulse(); //Run the pulse function. Might be bound to a key in the future.
        //}
    }

    void pulse() //At the push of a button...
    {
        if (isSource) //If this is a source become charged.
        {
            //Debug.Log("SourceCharge");
            charged = true;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {

        //Debug.Log("TOUCHY");

        if (charged == true) //If this object is charged and not discharged...
        {
            other.SendMessage("Charge", SendMessageOptions.RequireReceiver); //Charge the other objects. Doesn't try and send to the floor.
            //Debug.Log("IF CHARGED TRUE");

        }
    }

    public void Charge() //When told...
    {
        if (!discharged) //If not discharged...
        {
            Debug.Log("NOT DISCHARGED");
            charged = true; //Become charged.
        }
    }
}
