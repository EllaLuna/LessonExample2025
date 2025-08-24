using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;
    string scorePrefix = "Score: ";
    TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = $"{scorePrefix}{currentScore}";
    }

    public void UpdateScoreText(int scoreToAdd)
    {
        scoreToAdd += currentScore;
        currentScore = scoreToAdd < 0 ? 0 : scoreToAdd;
        scoreText.text = $"{scorePrefix}{currentScore}";
    }
}
