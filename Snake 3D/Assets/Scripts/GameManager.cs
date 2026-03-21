using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Menu,
        Playing,
        Settings,
        GameOver
    }

    public GameState currentState;

    public UnityEvent onPlay;
    public UnityEvent onSettings;
    public UnityEvent onGameOver;

    void Awake()
    {
        Instance = this;
    }

     public void SetState(GameState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case GameState.Playing:
                Time.timeScale = 1f;
                onPlay?.Invoke();
                break;

            case GameState.Settings:
                Time.timeScale = 0f;
                onSettings?.Invoke();
                break;

            case GameState.GameOver:
                Time.timeScale = 0f;
                onGameOver?.Invoke();
                break;
        }
    }
}
