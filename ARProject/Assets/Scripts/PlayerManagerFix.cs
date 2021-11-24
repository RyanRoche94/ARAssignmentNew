using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerFix : MonoBehaviour
{

    NewPlayerMove newPlayerMove;

    public void Awake()
    {
        newPlayerMove = GetComponent<NewPlayerMove>();
    }

    private void Update()
    {
        newPlayerMove.HandleInputs();
    }
    private void FixedUpdate()
    {
        newPlayerMove.HandleMovements();
    }
}
