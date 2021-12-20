using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNavBound : MonoBehaviour
{
    public GameObject backPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onInput()
    {
        gameObject.transform.position = backPoint.transform.position; //When the input is received, return to the given point.
    }
}
