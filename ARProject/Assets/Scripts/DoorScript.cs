using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class DoorScript : MonoBehaviour
{
    private bool timestart;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timestart)
        {
            timer += Time.deltaTime; //Start a timer when told
        }

        if (timer >= 2)
        {
            gameObject.transform.position += new Vector3(0, -1000, 0); //If the timer is up, shoot back down
            timer = 0;
            timestart = false; //Stop and reset the timer.
        }
    }

    public void Charge()
    {
        gameObject.transform.position += new Vector3(0, 1000, 0); //Shoot up (to stay active and still be out of the way)
        timestart = true; //Start a timer.
    }
}
