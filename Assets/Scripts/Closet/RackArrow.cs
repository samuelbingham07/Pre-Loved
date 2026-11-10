using UnityEngine;

// Put this on the small arrows under the rack (needs a BoxCollider2D).
public class RackArrow : MonoBehaviour, IInteractable
{
    public RackController rack;

    // 1 = next frame, -1 = previous frame
    public int direction = 1;
    public string label = "";

    public float hoverScale = 1.15f;

    Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    public string InteractText()
    {
        return label;
    }

    public void Interact()
    {
        rack.Slide(direction);
    }

    public void SetHover(bool isHovered)
    {
        if (isHovered)
        {
            transform.localScale = startScale * hoverScale;
        }
        else
        {
            transform.localScale = startScale;
        }
    }
}
