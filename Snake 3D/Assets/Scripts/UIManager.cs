using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject settingsUI;


    void Start()
    {
        GameManager.Instance.onPlay.AddListener(ShowGame);
        GameManager.Instance.onGameOver.AddListener(ShowGameOver);
        GameManager.Instance.onSettings.AddListener(ShowSettings);
    }
    void OnDestroy()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
        
        GameManager.Instance.onPlay.RemoveListener(ShowGame);
        GameManager.Instance.onGameOver.RemoveListener(ShowGameOver);
        GameManager.Instance.onSettings.RemoveListener(ShowSettings);
    }

    void ShowGame()
    {
        gameOverUI.SetActive(false);
        settingsUI.SetActive(false);
    }
    void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        settingsUI.SetActive(false);
    }
    void ShowSettings()
    {
        gameOverUI.SetActive(false);
        settingsUI.SetActive(true);
    }
}
