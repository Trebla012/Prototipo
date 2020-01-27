using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Observer : MonoBehaviour
{
    public Transform player;

    public bool isPlayerOnTarget;

    RaycastHit raycastHit;

    WayPointPatrol AI;


    private void Start()
    {
        AI = GetComponent<WayPointPatrol>();
        player = GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerOnTarget = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            isPlayerOnTarget = false;
        }
    }

    private void Update()
    {
        if (isPlayerOnTarget)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;

            Ray ray = new Ray(transform.position, direction);

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
        
                {
                    AI.navMeshAgent.SetDestination(player.transform.position);
                }
            }
           
        }
        
    }
}