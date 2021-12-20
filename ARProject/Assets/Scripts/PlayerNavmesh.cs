using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavmesh : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform movePos;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();  
    }
    private void Update()
    {
        navMeshAgent.destination = movePos.position;
    }
}
