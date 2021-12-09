using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMove : MonoBehaviour
{

    PlayerControler playercontrols;
    public Vector2 movementInput;

    Vector3 moveDirection;
    public Transform cameraObject;

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
        moveDirection = (cameraObject.forward * verticleInput) + (cameraObject.up * verticleInput);
        moveDirection = moveDirection + cameraObject.right * horizontalInput;
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

    private void Rotation()
    {
        Vector3 targetDirection = Vector3.zero;
       
        targetDirection = cameraObject.forward * verticleInput;
        targetDirection = targetDirection + cameraObject.right * horizontalInput;
        targetDirection.Normalize();

        targetDirection.y = 0;

        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.rotation = playerRotation;
    }

    public void HandleMovements()
    {
        Movement();
        MovementInput();
        Rotation();
    }
    public void HandleInputs()
    {
        MovementInput();
    }

}
