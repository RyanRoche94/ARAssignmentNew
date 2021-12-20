using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{

    PlayerControler playercontrols;
    public Vector2 movementInput;

    Vector3 moveDirection;
    

    public float verticleInput;
    public float horizontalInput;

    Rigidbody playerRigidbody;
    public float movementSpeed = 7;
    public float rotationSpeed = 15;

    private void OnEnable()
    {
        if (playercontrols == null)
        {
            playercontrols = new PlayerControler();
            playercontrols.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }

        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    public void Awake ()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //cameraObject = Camera.main.transform;
    }
    

    public void Movement()
    {
        moveDirection = new Vector3(horizontalInput, 0, verticleInput);
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection = moveDirection * movementSpeed;
        Vector3 movementVelocity = moveDirection;
        playerRigidbody.velocity = movementVelocity;
    }

    private void MovementInput ()
    {
        verticleInput = movementInput.y;
        horizontalInput = movementInput.x;
    }

    

    public void HandleMovements()
    {
        Movement();
        MovementInput();
    }
    public void HandleInputs()
    {
        MovementInput();
    }

}
