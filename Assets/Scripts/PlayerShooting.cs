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
    private float bulletForce = 20f * UpgradeData.bulletUpgradeCoefficient;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"bullet Upgrade Coefficient is {UpgradeData.bulletUpgradeCoefficient}");
            if (bulletForce == 20)
            {
            bulletForce *= UpgradeData.bulletUpgradeCoefficient;
            }
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
