using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private string scoreName;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    public int Score
    {
        set { score = value; }
    }

    private void Start()
    {
        scoreText.text = ScoreValue(score, scoreName);
    }

    private string ScoreValue(int score, string name)
    {
        string scoreName = name + score;
        return scoreName;
    }

    public async Task CountScore()
    {
        while (score != 0)
        {
            score--;
            scoreText.text = ScoreValue(score, scoreName);
            scoreManager.totalScoreValue++;
            scoreManager.totalScoreText.text = ScoreValue(scoreManager.totalScoreValue, "Total Score: ");
            await Task.Yield();
        } 
    }



}
