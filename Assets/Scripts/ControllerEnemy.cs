using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerEnemy : MonoBehaviour
{
    public NavMeshAgent agent;    // Referencia al NavMeshAgent del enemigo
    public Transform player;     // Referencia al Transform del jugador

    // Update se llama una vez por frame
    void Update()
    {
        if (player != null) // Verifica que el jugador exista
        {
            // Mover al enemigo hacia la posición del jugador
            agent.SetDestination(player.position);
        }
    }
}

