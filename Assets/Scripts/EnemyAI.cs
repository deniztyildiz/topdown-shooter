using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private int collisionDamage = 10; // How much damage the enemy deals on contact.
    private GameObject player;
    private PlayerHealth playerHealthScript;

    [Header("Effects")]
    [SerializeField]
    private GameObject hitEffectPrefab;
    private Transform playerTransform;
    private int currentHealth = 100;
    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealthScript = player.GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody2D>();
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

    public void EnemyTakeDamage(int damage)
    {
        if (hitEffectPrefab != null)
        {
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        }

        currentHealth -= damage;

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
        GameObject collidedObject = collision.gameObject;
        if(collidedObject == player)
        {
            playerHealthScript.TakeDamage(collisionDamage);
        }
        Die();

    }
}