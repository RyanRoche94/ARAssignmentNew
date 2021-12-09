using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetY : MonoBehaviour
{

    public GameObject yLevel;

    // Update is called once per frame
    public void Update()
    {
        float xPos = gameObject.transform.position.x;
        float yPos = yLevel.transform.position.y;
        float zPos = gameObject.transform.position.z;

        Vector3 newPos = new Vector3(xPos, yPos, zPos);

        gameObject.transform.position = newPos;
       
    }
}
