using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // --- Public Fields ---
    [Header("References")]
    [Tooltip("The bullet prefab that will be shot.")]
    [SerializeField]
    private GameObject bulletPrefab;

    [Tooltip("The point from where the bullet will be spawned.")]
    [SerializeField]
    private Transform firePoint;

    [Header("Shooting Settings")]
    [SerializeField]
    private float bulletForce = 20f;

    // --- Private Variables ---
    private Camera mainCamera;
    private Rigidbody2D rb;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // --- Aiming Logic ---
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


        // --- Shooting Logic (THIS LINE IS CHANGED) ---
        // Check for the Space key press instead of the mouse button.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            Debug.Log("Bullet shooted");
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Bullet Prefab or Fire Point is not set!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}