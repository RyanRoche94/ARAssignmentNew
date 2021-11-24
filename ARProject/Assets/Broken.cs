using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken: MonoBehaviour
{
    NewPlayerMove newPlayerMove;

    private void Awake()
    {
        newPlayerMove = GetComponent<NewPlayerMove>();


    }
}
