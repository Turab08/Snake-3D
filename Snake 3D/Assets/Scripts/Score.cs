using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    TMP_Text scoreText;
    [SerializeField] Animator animator;
    public static Score Instance;
    int score = 0;
    int highScore = 0;

    float elapsedTime = 0f;

    void Awake()
    {
        Instance = this;
        scoreText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }
    public void AddScore(int amount)
    {
        score += amount * (int)Math.Pow(1.05, elapsedTime);
        scoreText.text = $"Score: {score}";

        highScore = Math.Max(score, highScore);
        PlayerPrefs.SetInt("HighScore", highScore);

        animator.SetBool("ScoreChanged", true);
        StartCoroutine(FinishAnimation());
    }   

    IEnumerator FinishAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("ScoreChanged", false);
    } 
}
