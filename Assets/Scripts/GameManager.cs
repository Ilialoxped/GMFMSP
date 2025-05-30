using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int EnemyScore = 50;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateScoreUI();
    }
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {   
            scoreText.text = "Очки: " + score;
    }
    public void EnemyKilled()
    {
        AddScore(EnemyScore);
    }
}
