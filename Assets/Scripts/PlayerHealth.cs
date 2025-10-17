using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 10;
    private int currentHealth;

    // We use a static event to broadcast that health has changed.
    public static event Action<int, int> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Prevent health from going below zero
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        // Broadcast the event to any listeners
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        Debug.Log($"Player health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player has died!");
    }
}