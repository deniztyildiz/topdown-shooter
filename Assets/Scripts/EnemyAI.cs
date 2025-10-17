using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField]
    private int collisionDamage = 10; // How much damage the enemy deals on contact.

    [Header("Effects")]
    [SerializeField]
    private GameObject hitEffectPrefab;

    private Transform playerTransform;
    private int currentHealth;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ScoreManager.AddKill();
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy collided with the player");
        Die();
    }
}