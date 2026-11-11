using UnityEngine;

public class DetailSpot : MonoBehaviour, IInteractable
{
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
