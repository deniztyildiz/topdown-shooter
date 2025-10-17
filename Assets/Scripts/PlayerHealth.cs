using UnityEngine;
using System; // Required for using Actions (Events)

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    private int currentHealth;

    // We use a static event to broadcast that health has changed.
    // This is a clean way to let the UI update without a direct link.
    public static event Action<int, int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Prevent health from going below zero
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        // Broadcast the event to any listeners (like our health bar)
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        Debug.Log($"Player health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Here you would handle player death (e.g., play an animation, show a "Game Over" screen)
        Debug.Log("Player has died!");
        // For now, we can just destroy the player object
        Destroy(gameObject);
    }
}