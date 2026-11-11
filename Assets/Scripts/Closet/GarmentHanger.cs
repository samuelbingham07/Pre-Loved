using UnityEngine;

public class GarmentHanger : MonoBehaviour, IInteractable
{
    public GarmentData garment;

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
            GameManager.instance.selectedGarment = garment;
            ViewManager.instance.GoToView(mirrorView);
        }
    }

    public void SetHover(bool isHovered)
    {
    }
}
