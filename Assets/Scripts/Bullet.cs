using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;

    void Start()
    {
        // Destroy the bullet after 5 seconds if it hasn't hit anything.
        Destroy(gameObject, 5f);
    }

    // This function is called when the bullet's collider enters another collider.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyAI enemy = hitInfo.GetComponent<EnemyAI>();
        if (enemy != null)
        {
            // If it hits an enemy, deal damage.
            enemy.EnemyTakeDamage(damage);
        }

        // Destroy the bullet as soon as it hits any object with a collider.
        Destroy(gameObject);
    }
}
