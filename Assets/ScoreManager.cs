using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Threading.Tasks;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private Button scoreBtn;
    [SerializeField] private ScoreCount[] scoreCounters;
    public TextMeshProUGUI totalScoreText;
    [SerializeField] public GameObject completeText;

    public int totalScoreValue;

    private void Awake()
    {
        
        for (int i = 0; i < scoreCounters.Length; i++)
        {
            int num = i + 1;
            scoreCounters[i].Score = 500 * 2 * num;
        }

        scoreBtn.onClick.AddListener(StartScoreCount);
        completeText.gameObject.SetActive(false);


    }

    private async void StartScoreCount()
    {

        var tasks = new Task [scoreCounters.Length];

        for ( int i = 0;i < scoreCounters.Length; i++)
        {
            tasks[i] = scoreCounters[i].CountScore();
        }
        await Task.WhenAll(tasks);

        completeText.gameObject.SetActive(true);

    }


}
