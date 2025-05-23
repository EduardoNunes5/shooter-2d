using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    private const string ScoreTemplate = "SCORE\n{0:D5}";
    private const string HighestScoreTemplate = "HI-SCORE\n{0:D5}";
    
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private TextMeshProUGUI highestScoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = string.Format(ScoreTemplate, score);
    }

    public void UpdateHighestScore(int score)
    {
        highestScoreText.text = string.Format(HighestScoreTemplate, score);
    }
}
