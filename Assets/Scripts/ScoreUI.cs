using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        // Find the Text component if it's not assigned in the inspector.
        scoreText ??= GetComponent<TextMeshProUGUI>();
        
        // Subscribe to the event.
        ScoreManager.OnScoreChanged += UpdateScoreText;

        // --- IMPORTANT ---
        // Set the initial text when the game starts.
        scoreText.text = $"Kills: {ScoreManager.enemiesKilled}";
    }

    void OnDestroy()
    {
        // Unsubscribe to prevent errors.
        ScoreManager.OnScoreChanged -= UpdateScoreText;
    }

    // This function is called by the OnScoreChanged event.
    private void UpdateScoreText(int newScore)
    {
        scoreText.text = $"Kills: {newScore}";
    }
}