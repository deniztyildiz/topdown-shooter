using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private Camera mainCamera;
    private float camHeight;
    private float camWidth;
    
    // To make sure the entire player sprite stays on screen, we need its size.
    private float playerHalfWidth;
    private float playerHalfHeight;

    void Start()
    {
        mainCamera = Camera.main;
        
        // Get the player's SpriteRenderer to determine its size.
        SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
        if (playerSprite != null)
        {
            // bounds.extents gives you half of the sprite's width and height.
            playerHalfWidth = playerSprite.bounds.extents.x;
            playerHalfHeight = playerSprite.bounds.extents.y;
        }
        else
        {
            Debug.LogWarning("Player needs a SpriteRenderer component to calculate bounds.");
        }
    }

    // LateUpdate runs after all other Update calls, which is ideal for camera-related logic.
    void LateUpdate()
    {
        // Calculate the camera's dimensions in world units.
        camHeight = mainCamera.orthographicSize;
        camWidth = camHeight * mainCamera.aspect;

        // Calculate the boundaries of the camera's view in world space.
        float minX = mainCamera.transform.position.x - camWidth + playerHalfWidth;
        float maxX = mainCamera.transform.position.x + camWidth - playerHalfWidth;
        float minY = mainCamera.transform.position.y - camHeight + playerHalfHeight;
        float maxY = mainCamera.transform.position.y + camHeight - playerHalfHeight;

        // Get the player's current position.
        Vector3 currentPos = transform.position;

        // Use Mathf.Clamp to restrict the player's x and y coordinates to be within the boundaries.
        currentPos.x = Mathf.Clamp(currentPos.x, minX, maxX);
        currentPos.y = Mathf.Clamp(currentPos.y, minY, maxY);

        // Apply the clamped position back to the player.
        transform.position = currentPos;
    }
}