using UnityEngine;
using UnityEngine.SceneManagement; // Para manejar las escenas
using UnityEngine.UI;  // Para trabajar con los UI buttons

public class GameOverManager : MonoBehaviour
{
    public Button restartButton; // Referencia al bot�n de reiniciar

    void Start()
    {
        // Aseg�rate de que el bot�n est� asociado
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame); // Asocia la funci�n RestartGame al bot�n
        }
    }

    // Esta funci�n reinicia la escena del juego
    void RestartGame()
    {
        // Aseg�rate de usar el nombre correcto de tu escena del juego
        SceneManager.LoadScene("SampleScene"); 
    }
}
