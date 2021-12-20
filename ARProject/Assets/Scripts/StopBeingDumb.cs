using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBeingDumb : MonoBehaviour
{
    public GameObject dumbCatcher;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = dumbCatcher.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
