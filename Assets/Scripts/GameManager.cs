using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public TMP_Text textScore;   // arrástrale el ScoreText en el inspector

    private void Awake()
    {
        // Singleton simple (sin DontDestroyOnLoad porque recargas la misma escena)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        score = 0;          // cada vez que entras a la escena empieza en 0
        UpdateScoreUI();
    }

    public void AddScore(int amount = 1)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (textScore != null)
        {
            textScore.text = "Score: " + score;
        }
    }
}
