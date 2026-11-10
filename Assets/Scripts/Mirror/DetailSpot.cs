using UnityEngine;

// An invisible click area over one part of the hanging garment (needs a BoxCollider2D).
// Clicking it shows a close-up photo and a description.
public class DetailSpot : MonoBehaviour, IInteractable
{
    // Shown on hover, like "Collar" or "Stain"
    public string label;

    public Sprite closeUp;
    public string description;

    public string InteractText()
    {
        return label;
    }

    public void Interact()
    {
        InspectViewer.instance.Show(closeUp, description);
    }

    public void SetHover(bool isHovered)
    {
    }
}
