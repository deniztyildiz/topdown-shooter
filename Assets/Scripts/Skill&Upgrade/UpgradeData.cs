using UnityEngine;

public class UpgradeData : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    private Rigidbody2D rb;
    private PlayerHealth playerHealthScript;
    public static int bulletUpgradeCoefficient = 1;

    public int healingAmount;
    void Start()
    {
        healingAmount = 50;
        playerHealthScript = player.GetComponent<PlayerHealth>();
        playerHealthScript.Heal(healingAmount);
    }

    void GoldCounter()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreManager.enemiesKilled > 1 & bulletUpgradeCoefficient == 1)
        {
            bulletUpgradeCoefficient = 2;
            Debug.Log($"bullet upgrade coefficient is {bulletUpgradeCoefficient}");
        }
    }
}
