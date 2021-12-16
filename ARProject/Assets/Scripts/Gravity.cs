using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public GameObject gravityTarget;
    Vector3 gravityDirection;
    Rigidbody myRigidbody;

    public float gravityForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = this.GetComponent<Rigidbody>();
        gravityDirection = new Vector3(0, gravityTarget.transform.position.y, 0).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.AddForce(gravityDirection * gravityForce);
    }
}
