using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{   
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }
    public void Settings()
    {
        GameManager.Instance.SetState(GameManager.GameState.Settings);
    }
    public void Play()
    {
        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }

    public void NormalMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HardMode()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
