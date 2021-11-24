using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElectroScript : MonoBehaviour
{
    public Material onmaterial;
    public Material offmaterial;
    
    public bool isSource;

    public bool charged = false;

    public bool discharged = false;

    public float timer = 0;
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
            material = onmaterial;
        }
        else if (!charged)
        {
            material = offmaterial;
            Debug.Log("Uncharged");
        }
        
        Debug.Log(discharged);

        //if (Input.GetKeyDown(KeyCode.F))
        //{
            pulse();
        //}
    }

    void pulse() //At the push of a button...
    {
        if (isSource) //If this is a source become charged.
        {
            Debug.Log("SourceCharge");
            charged = true;
        }
    }

     void OnCollisionStay(Collision collision) //To all touching objects...
    {
        Debug.Log("TOUCHY");

        if (charged == true) //If this object is charged and not discharged...
        {
            collision.gameObject.SendMessage("Charge"); //Charge the other objects.
            Debug.Log("IF CHARGED TRUE");


            if (!isSource)
            {
                charged = false; //Become not charged.
                discharged = true; //Become discharged.
            }
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
