using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas
using UnityEngine.UI;  // Para trabajar con los UI buttons

public class GameOverManager : MonoBehaviour
{
    public Button restartButton; // Referencia al botón de reiniciar

    void Start()
    {
        // Asegúrate de que el botón esté asociado
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame); // Asocia la función RestartGame al botón
        }
    }

    // Esta función reinicia la escena del juego
    void RestartGame()
    {
        // Asegúrate de usar el nombre correcto de tu escena del juego
        SceneManager.LoadScene("SampleScene"); 
    }
}
