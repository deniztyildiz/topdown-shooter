using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Make variables visible and editable in the inspector
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    // Update is called once per frame
    void Update()
    {
        // Get movement input with keys
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Get mouse position from camera perspective
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    // FixedUpdate is called on a fixed timer and is the best one to use for pyhsics.
    void FixedUpdate()
    {
        // Handle Movement
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // Handle Rotation
        // Calculate the direction from player to the mouse
        Vector2 lookDirection = mousePosition - rb.position;
        // Calculate the angle in degrees
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
