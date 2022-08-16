using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Paused : MonoBehaviour
{
    public string restartGame;
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMenu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(restartGame);
    }
}