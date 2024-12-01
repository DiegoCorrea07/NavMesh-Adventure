using UnityEngine;
using UnityEngine.UI;  // Para trabajar con UI
using UnityEngine.SceneManagement;  // Para cambiar escenas

public class PlayerHealth : MonoBehaviour
{
    public int health = 5; // N�mero de golpes que el jugador puede recibir
    private bool isDead = false; // Para evitar m�ltiples destrucciones del jugador
    public Slider healthSlider; // Referencia al Slider de la barra de salud en la UI

    void Start()
    {
        // Aseg�rate de que el Slider est� lleno al inicio
        UpdateHealthSlider();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el jugador colisiona con un enemigo
        if (!isDead && collision.gameObject.CompareTag("Enemy"))
        {
            // Reducir la vida del jugador por cada golpe
            health--;

            // Actualizar el Slider
            UpdateHealthSlider();

            // Si el jugador ha recibido 5 golpes, se destruye
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (!isDead)
        {
            isDead = true;
            // Mostrar la pantalla de Game Over
            ShowGameOver();
            // Destruir al jugador (o puedes desactivar el objeto)
            Destroy(gameObject);
        }
    }

    void ShowGameOver()
    {
        // Aqu� puedes cargar una escena de "Game Over" o activar un Canvas de UI
        SceneManager.LoadScene("GameOverScene"); // Aseg�rate de que esta escena exista
    }

    void UpdateHealthSlider()
    {
        // Actualiza el valor del Slider
        healthSlider.value = health; // El valor se actualiza seg�n la salud actual
    }
}
