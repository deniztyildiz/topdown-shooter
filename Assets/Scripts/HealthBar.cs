using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;

    // We subscribe in Awake() to make sure we are listening before PlayerHealth sends its first message.
    void Awake()
    {
        PlayerHealth.OnHealthChanged += UpdateHealthBar;
    }

    // We unsubscribe in OnDestroy() which is the counterpart to Awake().
    void OnDestroy()
    {
        PlayerHealth.OnHealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthSlider.value = (float)currentHealth / maxHealth;
    }
}