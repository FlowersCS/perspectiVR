using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas o salir del juego

public class EndGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el trigger
        if (other.CompareTag("Player"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("¡Juego Terminado!");
        // Puedes cargar una escena de fin o cerrar el juego
        // SceneManager.LoadScene("EndScene"); // Opcional, cargar escena final
        Application.Quit(); // Cierra la aplicación
    }
}