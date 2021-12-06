using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class DoorScript : MonoBehaviour
{
    private bool timestart;

    private float timer;

    public GameObject mychild;
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
            mychild.SetActive(true); //If the timer is up, shoot back down
            timer = 0;
            timestart = false; //Stop and reset the timer.
        }
    }

    public void Charge()
    {
        mychild.SetActive(false);
        timestart = true; //Start a timer.
    }
}
