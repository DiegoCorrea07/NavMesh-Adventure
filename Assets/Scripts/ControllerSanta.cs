using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSanta : MonoBehaviour
{
    // Velocidad del personaje, ajustable desde el Inspector
    public float speed = 5f;

    // Variable para suavizar la rotación
    public float rotationSpeed = 10f;

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener el input del jugador (teclas WASD o flechas)
        float horizontal = Input.GetAxis("Horizontal"); // Movimiento lateral (izquierda/derecha)
        float vertical = Input.GetAxis("Vertical"); // Movimiento frontal (adelante/atrás)

        // Crear un vector de movimiento basado en la entrada del jugador
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Si el movimiento no es cero, mueve y rota el personaje
        if (movement != Vector3.zero)
        {
            // Mover el personaje
            transform.Translate(movement * speed * Time.deltaTime, Space.World);

            // Rotar el personaje hacia la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
