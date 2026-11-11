using UnityEngine;

public class RackArrow : MonoBehaviour, IInteractable
{
    public RackController rack;

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
