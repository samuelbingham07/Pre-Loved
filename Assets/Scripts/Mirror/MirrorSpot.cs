using UnityEngine;

// An invisible click area over the mirror in the background (needs a BoxCollider2D).
// Clicking it "tries on" the picked garment by showing the photo of me wearing it.
public class MirrorSpot : MonoBehaviour, IInteractable
{
    public string label = "Try it on";

    public string InteractText()
    {
        return label;
    }

    public void Interact()
    {
        GarmentData garment = GameManager.instance.selectedGarment;

        if (garment != null && garment.mirrorImage != null)
        {
            InspectViewer.instance.Show(garment.mirrorImage, garment.tryOnText);
        }
        else
        {
            print("No mirror photo for this garment yet");
        }
    }

    public void SetHover(bool isHovered)
    {
    }
}
