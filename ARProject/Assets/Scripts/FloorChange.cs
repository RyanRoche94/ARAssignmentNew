using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChange : MonoBehaviour
{
    public GameObject floor1;

    public GameObject floor2;

    private bool floor = false;


    public void input()
    {
        if (!floor) //If floor is false, meaning you are on floor 1...
        {
            transform.position = new Vector3(transform.position.x, floor2.transform.position.y, transform.position.z); //Go to floor 2's Y
            floor = true; //Set floor to true, telling you that you are on floor 2
        }
        else if (floor) //If floor is true, meaning you're on floor 2...
        {
            transform.position = new Vector3(transform.position.x, floor1.transform.position.y, transform.position.z); //Go to floor 1's Y
            floor = false; //Set floor to false, telling you that you're on floor 1.
        }
    }
}
