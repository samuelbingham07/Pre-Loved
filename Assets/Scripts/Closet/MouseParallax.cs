using UnityEngine;
using UnityEngine.InputSystem;

// Put this on each layer of a view. Back layers get a small strength,
// front layers a bigger one, so the closet feels like it has depth.
public class MouseParallax : MonoBehaviour
{
    public float strength = 0.05f;

    // Higher = layer catches up to the mouse faster
    public float smoothing = 5f;

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // How far the mouse is from the center of the camera, in world units
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 cameraPosition = Camera.main.transform.position;
        Vector2 offset = (mousePosition - cameraPosition) * strength;

        // Layers move opposite the mouse, like looking around a room
        Vector3 targetPosition = startPosition - new Vector3(offset.x, offset.y, 0);

        // Move a small step toward the target each frame (this is the smoothing)
        transform.position += (targetPosition - transform.position) * smoothing * Time.deltaTime;
    }
}
