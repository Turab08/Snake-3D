using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreText : MonoBehaviour
{
    TMP_Text highScoreText;

    void Awake()
    {
        highScoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore")}";
    }
}
