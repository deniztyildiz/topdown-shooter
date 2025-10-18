using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    public static event Action<int, int> OnHealthChanged;

    void Awake()
    {
        maxHealth = 1000;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Prevent health from going below zero
        currentHealth = Mathf.Max(currentHealth - damage, 0);

        // Broadcast the event to any listeners
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
    }

    public void Die()
    {
        Debug.Log("Player has died!");
    }
}
