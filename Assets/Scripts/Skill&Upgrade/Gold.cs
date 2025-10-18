using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public static int gold;
    public TextMeshProUGUI goldText;

    void Awake()
    {
        goldText.text = $"Gold: {gold}";
    }
    void Update()
    {
        gold = ScoreManager.enemiesKilled;
        goldText.text = $"Gold: {gold}";
    }
}
