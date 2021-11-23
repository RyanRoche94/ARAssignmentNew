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
            timer += Time.deltaTime; //Start a timer.
            if (timer >= 3) //After 3 seconds...
            {
                discharged = false; //Stop being discharged.
                timer = 0; //And reset the timer.
            }
        }

        if (charged)
        {
            Debug.Log("Zap");
            material = onmaterial;
        }
        else if (!charged)
        {
            material = offmaterial;
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
            charged = true;
        }
    }

    public void OnCollisionStay(Collision collision) //To all touching objects...
    {

        if (charged) //If this object is charged and not discharged...
        {
            collision.gameObject.SendMessage("Charge"); //Charge the other objects.



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
            charged = true; //Become charged.
        }
    }
}
