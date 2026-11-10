using UnityEngine;

// An invisible click area over a garment in the closet picture (needs a BoxCollider2D).
// Clicking it takes the garment out and hangs it in front of the mirror.
public class GarmentHanger : MonoBehaviour, IInteractable
{
    public GarmentData garment;

    // Index of the Mirror in ViewManager's list
    public int mirrorView = 1;

    public string InteractText()
    {
        if (garment == null)
        {
            return "";
        }
        else
        {
            return garment.displayName;
        }
    }

    public void Interact()
    {
        if (garment == null)
        {
            print("Nothing to pick here");
        }
        else
        {
            // Remember this garment so the Mirror knows which one to hang up
            GameManager.instance.selectedGarment = garment;
            ViewManager.instance.GoToView(mirrorView);
        }
    }

    // The garment is part of the closet picture, so there's nothing to change on hover.
    // (The hover text still shows its name.)
    public void SetHover(bool isHovered)
    {
    }
}
