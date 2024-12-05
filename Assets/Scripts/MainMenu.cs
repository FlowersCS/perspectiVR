using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Cambia "GameScene" por el nombre de tu escena de juego
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(0); // Cambia "TutorialScene" por el nombre de tu escena de tutorial
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra la aplicación
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Solo para editor
#endif
    }
}