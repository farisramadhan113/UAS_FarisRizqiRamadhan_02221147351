using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int scoreValue;

    private void Start()
    {
        scoreValue = 0;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Pastikan scoreText tidak null sebelum m  encoba mengubah teks
        if (scoreText != null)
        {
            scoreText.text = "APPLE: " + scoreValue.ToString();
        }
    }
}
